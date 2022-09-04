using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.RegisterCustomer.Configuration;

namespace WebApi.RegisterCustomer
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.GeneralSettingsDependencyInversionServices(Configuration);
      services.GeneralSettingsServices();
      services.DatabaseSettingsDependencyInversion(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseGeneralSettingsBuilder(env);
    }
  }
}
