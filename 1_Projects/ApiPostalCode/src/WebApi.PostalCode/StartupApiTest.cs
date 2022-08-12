using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.PostalCode.Configuration;


namespace WebApi.PostalCode
{
  public class StartupApiTest
  {
    public StartupApiTest(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.GeneralSettingsDependencyInversionServices(Configuration);
      services.GeneralSettingsServices();
      services.SwaggerConfigServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
      app.UseGeneralSettingsBuilder(env);
      app.UseSwaggerConfig(provider);
    }
  }
}
