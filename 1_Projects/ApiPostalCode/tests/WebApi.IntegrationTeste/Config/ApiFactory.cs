using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.IntegrationTeste.Config
{
  public class ApiFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder.UseStartup<TStartup>();
      builder.UseEnvironment("Development");
    }
  }
}
