using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.PostalCode.Configuration;


namespace WebApi.PostalCode
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
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseGeneralSettingsBuilder(env);
    }
  }
}
