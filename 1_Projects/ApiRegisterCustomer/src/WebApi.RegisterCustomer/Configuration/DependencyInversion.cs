using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.CustomerServices;
using WebApi.Application.ICustomerServices;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.Infrastructure.Repository;

namespace WebApi.RegisterCustomer.Configuration
{
  public static class DependencyInversion
  {
    public static IServiceCollection GeneralSettingsDependencyInversionServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<IExternalHttpManagerServices, ExternalHttpManagerServices>();
      services.AddScoped<IPostalCodeServices, PostalCodeServices>();

      return services;
    }
  }
}
