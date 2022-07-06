using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Infrastructure.Context;

namespace WebApi.RegisterCustomer.Configuration
{
  public static class DataBaseInversion
  {
    public static IServiceCollection DatabaseSettingsDependencyInversion(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
      });

      return services;
    }
  }
}
