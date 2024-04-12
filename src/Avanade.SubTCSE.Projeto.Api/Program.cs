using Avanade.SubTCSE.Projeto.Api.FilterType;
using Avanade.SubTCSE.Projeto.Api.Swagger;
using Avanade.SubTCSE.Projeto.Infra.CrossCutting;
using Avanade.SubTCSE.Projeto.Infra.Database.Maps.Setup;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Avanade.SubTCSE.Projeto.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static readonly string _projectCORSLocal = "_projectCORS-Local";
        static readonly string _projectCORSServer = "_projectCORS-Server";

        protected Program() { }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: _projectCORSLocal,
                                       policy =>
                                       {
                                           policy.WithOrigins()
                                               .AllowAnyMethod()
                                               .AllowAnyOrigin()
                                               .AllowAnyHeader();
                                       });

                options.AddPolicy(name: _projectCORSServer,
                                       policy =>
                                       {
                                           policy.WithOrigins()
                                               .WithMethods("PUT", "DELETE", "GET", "PATCH")
                                               .AllowAnyOrigin()
                                               .WithHeaders("treinamento", "full-stack")
                                               .WithHeaders("Accept-Language", "pt-br");
                                       });
            });

            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    opt.JsonSerializerOptions.WriteIndented = true;
                    opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            builder.Services.AddSwaggerExtension();

            builder.Services
                .AddControllers(config =>
                {
                    config.Filters.Add<ExceptionFilter>();
                    config.RequireHttpsPermanent = true;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.AllowTrailingCommas = false;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new BadRequestObjectResult(context.ModelState);

                        result.ContentTypes.Add(MediaTypeNames.Application.Json);
                        result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                        return result;
                    };
                });

            builder.Services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            })
            .AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            builder.Services.AddRouting(opt =>
            {
                opt.LowercaseUrls = true;
                opt.LowercaseQueryStrings = true;
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOptions();

            builder.Services
                .AddLogging(configs =>
                {
                    configs.ClearProviders();
                    configs.AddConfiguration(builder.Configuration.GetSection("Logging"));
                    configs.AddConsole();
                    configs.AddApplicationInsights();
                    configs.AddDebug();
                });

            builder.Services.AddRegisterDependencyInjections();

            SetupMap.ConfigureMaps();

            builder.Services.AddApplicationInsightsTelemetry(options =>
            {
                options.EnableHeartbeat = true;
                options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
            });

            builder.Services.ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) =>
            {
                module.AuthenticationApiKey = builder.Configuration["ApplicationInsights:ApiKey"];
            });

            builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
            {
                module.EnableSqlCommandTextInstrumentation = true;
            });

            var app = builder.Build();

            app.UseSwaggerExtension();

            app.UseResponseCompression();

            app.UseHttpsRedirection();

            var cultures = new[] { "pt-BR", "en-US" };

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(cultures[0])
                .AddSupportedCultures(cultures);

            app.UseRequestLocalization(localizationOptions);

            if (app.Environment.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                        options =>
                        {
                            options.Run(
                                async context =>
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    context.Response.ContentType = "text/html";
                                    var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                                    if (null != exceptionObject)
                                    {
                                        var errorMessage = $"<b>Error:" +
                                        $" {exceptionObject.Error.Message}</b>" +
                                        $" {exceptionObject.Error.StackTrace}";

                                        await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                                    }
                                });
                        });
            }

            app.UseHttpsRedirection();

            app.UseCors(policyName: _projectCORSLocal);

            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers().RequireCors(policyName: _projectCORSLocal);

            app.Run();
        }
    }
}