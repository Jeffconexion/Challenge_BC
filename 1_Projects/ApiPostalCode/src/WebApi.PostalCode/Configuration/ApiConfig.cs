﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace WebApi.PostalCode.Configuration
{
  public static class ApiConfig
  {
    public static IServiceCollection GeneralSettingsServices(this IServiceCollection services)
    {
      services.AddControllers();

      services.AddApiVersioning(options =>
      {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
        options.AssumeDefaultVersionWhenUnspecified = true;
      });

      services.AddVersionedApiExplorer(options =>
      {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
      });

      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.SuppressModelStateInvalidFilter = true;

      });

      services.AddCors(options =>
      {
        options.AddPolicy("Development",
            builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


        options.AddPolicy("Production",
            builder =>
                builder
                    .WithMethods("GET")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                    .AllowAnyHeader());
      });

      return services;

    }

    public static IApplicationBuilder UseGeneralSettingsBuilder(this IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseCors("Development");
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseCors("Development");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseRouting();

      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      return app;
    }
  }
}
