using Avanade.SubTCSE.Projeto.Api.FilterType;
using Avanade.SubTCSE.Projeto.Infra.CrossCutting;
using Avanade.SubTCSE.Projeto.Infra.Database.Maps.Setup;
using HealthChecks.UI.Client;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Avanade.SubTCSE.Projeto.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public IWebHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration,
          IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
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

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 1);
            })
            .AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Avanade.SubTCSE.Projeto.Api", Version = "v1" });
                });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            })
            .AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddOptions();

            services
                .AddLogging(configs =>
                {
                    configs.AddConfiguration(_configuration.GetSection("Logging"));
                    configs.AddConsole();
                    configs.AddDebug();
                });

            services.AddRegisterDependencyInjections();

            SetupMap.ConfigureMaps();

            services.AddApplicationInsightsTelemetry(options =>
            {
                options.ConnectionString = _configuration["ApplicationInsights:ConnectionString"];
            });

            services.ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) =>
            {
                module.AuthenticationApiKey = _configuration["ApplicationInsights:ApiKey"];
            });

            services.AddLocalization(opt => 
            {
                
            });

            //services
            //    .AddHealthChecks();
            ////.AddMongoDb();

            //services
            //    .AddHealthChecksUI(setup =>
            //   {
            //       setup.SetApiMaxActiveRequests(1);
            //   })
            //    .AddInMemoryStorage();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
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
                                    $" { exceptionObject.Error.StackTrace}";

                                    await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                                }
                            });
                    }
                    );
            }

            app.UseCors(builder => builder.AllowAnyMethod()
                                          .AllowAnyOrigin()
                                          .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //c.RoutePrefix = string.Empty;
                options.DisplayRequestDuration();
                options.EnableValidator();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });

            app.UseResponseCompression();

            app.UseHttpsRedirection();

            var cultures = new[] { "pt-BR", "en-US"};

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(cultures[0])
                .AddSupportedCultures(cultures);

            app.UseRequestLocalization(localizationOptions);


            app.UseRouting();

            app.UseAuthorization();

            //app.UseHealthChecks("/hc", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            //app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapHealthChecks("/hc");
            });
        }
    }
}