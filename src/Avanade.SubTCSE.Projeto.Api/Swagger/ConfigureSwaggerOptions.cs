using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace Avanade.SubTCSE.Projeto.Api.Swagger
{
    [ExcludeFromCodeCoverage]
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var text = new StringBuilder("API para treinamento com .NET 8 e MongoDB");

            var info = new OpenApiInfo()
            {
                Title = "Avanade.SubTCSE.Projeto.Api .NET 8",
                Version = description.ApiVersion.ToString(),
                Description = $"WebApi criada para treinamento na Avanade v{Assembly.GetExecutingAssembly().GetName().Version}",
                Contact = new OpenApiContact()
                {
                    Email = "admin@felipementel.dev.br",
                    Name = "Felipe Augusto"
                },

            };

            IsDeprecated(description, text);
            IsActive(description, text);

            info.Description = text.ToString();

            return info;
        }

        private static void IsActive(ApiVersionDescription description, StringBuilder text)
        {
            if (description.SunsetPolicy is SunsetPolicy policy)
            {
                if (policy.Date is DateTimeOffset when)
                {
                    text.Append(" A API será desativada em ")
                        .Append(when.Date.ToShortDateString())
                        .Append('.');
                }

                if (policy.HasLinks)
                {
                    text.AppendLine();

                    for (var i = 0; i < policy.Links.Count; i++)
                    {
                        var link = policy.Links[i];

                        if (link.Type == "text/html")
                        {
                            AppendLink(text, link);
                        }
                    }
                }
            }
        }

        private static void AppendLink(StringBuilder text, LinkHeaderValue link)
        {
            text.AppendLine();

            if (link.Title.HasValue)
            {
                text.Append(link.Title.Value).Append(": ");
            }

            text.Append(link.LinkTarget.OriginalString);
        }

        private static void IsDeprecated(ApiVersionDescription description, StringBuilder text)
        {
            if (description.IsDeprecated)
            {
                text.Append(" Essa versão de API esta marcada como depreciada.");
            }
        }
    }
}