using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Integration.Teste.Config
{
  public class ApiFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      //Obtem uma class genérica.
      builder.UseStartup<TStartup>();

      //Obtem configurações do arquivo appsettings.Testing.json
      builder.UseEnvironment("Testing");
    }
  }
}
