﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.PostalCode.Configuration
{
  public static class SwaggerConfig
  {
    public static IServiceCollection SwaggerConfigServices(this IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.OperationFilter<SwaggerDefaultValues>();
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      return services;
    }

    public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
      app.UseSwagger();
      app.UseSwaggerUI(
          options =>
          {
            foreach (var description in provider.ApiVersionDescriptions)
            {
              options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
          });
      return app;
    }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
      readonly IApiVersionDescriptionProvider provider;

      public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

      public void Configure(SwaggerGenOptions options)
      {
        foreach (var description in provider.ApiVersionDescriptions)
        {
          options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
      }

      static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
      {
        var info = new OpenApiInfo()
        {
          Title = "API - Postal Code",
          Version = description.ApiVersion.ToString(),
          Description = "This Api is responsible for communicating with zip code services from other companies.",
          Contact = new OpenApiContact() { Name = "Jefferson Santos", Url = new Uri("https://www.linkedin.com/in/jeffsantosti/") },
          License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };

        if (description.IsDeprecated)
        {
          info.Description += " This version is obsolete!";
        }

        return info;
      }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
      public void Apply(OpenApiOperation operation, OperationFilterContext context)
      {
        if (operation.Parameters == null)
        {
          return;
        }

        foreach (var parameter in operation.Parameters)
        {
          var description = context.ApiDescription
              .ParameterDescriptions
              .First(p => p.Name == parameter.Name);

          var routeInfo = description.RouteInfo;

          operation.Deprecated = OpenApiOperation.DeprecatedDefault;

          if (parameter.Description == null)
          {
            parameter.Description = description.ModelMetadata?.Description;
          }

          if (routeInfo == null)
          {
            continue;
          }

          if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
          {
            parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
          }

          parameter.Required |= !routeInfo.IsOptional;
        }
      }
    }

    public class SwaggerAuthorizedMiddleware
    {
      private readonly RequestDelegate _next;

      public SwaggerAuthorizedMiddleware(RequestDelegate next)
      {
        _next = next;
      }

      public async Task Invoke(HttpContext context)
      {
        if (context.Request.Path.StartsWithSegments("/swagger")
            && !context.User.Identity.IsAuthenticated)
        {
          context.Response.StatusCode = StatusCodes.Status401Unauthorized;
          return;
        }

        await _next.Invoke(context);
      }
    }
  }
}




