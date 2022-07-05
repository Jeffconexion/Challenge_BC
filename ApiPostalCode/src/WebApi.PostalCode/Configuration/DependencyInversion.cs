using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApi.Application.Config;
using WebApi.Application.IServices;
using WebApi.Application.Services;
using static WebApi.PostalCode.Configuration.SwaggerConfig;

namespace WebApi.PostalCode.Configuration
{
  public static class DependencyInversion
  {
    public static IServiceCollection GeneralSettingsDependencyInversionServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<ZipsSettings>(configuration.GetSection("ZipsSettings"));
      services.AddScoped<IOutsourcingPostalCodeServices, OutsourcingPostalCodeServices>();
      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

      return services;
    }
  }
}
