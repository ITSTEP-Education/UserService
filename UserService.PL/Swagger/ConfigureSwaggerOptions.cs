﻿using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AspNetWeb_Product.Swagger
{
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

        //public void Configure(string? name, SwaggerGenOptions options) => Configure(options);

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            //Add description by versioning of Api in SwaggerUI
            var info = new OpenApiInfo()
            {
                Version = description.ApiVersion.ToString(),
                Title = "UserService Api",
                Description = "Api request to get OrderDetail, ClientData and ClientOrder",
                Contact = new OpenApiContact
                {
                    Name = "KostiantynPolishko",
                    Email = "polxs_wp31@student.itstep.org",
                    Url = new Uri("https://github.com/ITSTEP-Education/UserService")
                },
                License = new OpenApiLicense
                {
                    Name = "ApiITSTEP",
                    Url = new Uri("https://mystat.itstep.org/")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += $"This API {info.Version} has been deprecated";
            }

            return info;
        }
    }
}
