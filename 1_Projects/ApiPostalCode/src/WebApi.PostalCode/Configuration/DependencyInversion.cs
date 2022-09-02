using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.IServices;
using WebApi.Application.Services;
using WebApi.Infrastructure.Config;

namespace WebApi.PostalCode.Configuration
{
  public static class DependencyInversion
  {
    public static IServiceCollection GeneralSettingsDependencyInversionServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<ZipsSettings>(configuration.GetSection("ZipsSettings"));
      services.AddScoped<IOutsourcingPostalCodeServices, OutsourcingPostalCodeServices>();

      return services;
    }
  }
}
