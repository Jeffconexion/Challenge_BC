using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.Infrastructure.ExternalServices.IExternalServices;

namespace WebApi.Infrastructure.ExternalServices
{
  public class ExternalHttpManagerServices : IExternalHttpManagerServices
  {
    public async Task<TOutput> CallGetApiPostalCode<TOutput, TInput>(TInput requestBody, string endpoint, HttpMethod verb) where TInput : HttpContent
    {
      using var client = new HttpClient();
      client.BaseAddress = new Uri("https://localhost:44338/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      var apiPostalCodeRequest = new HttpRequestMessage(verb, endpoint) { Content = requestBody };
      var apiPostalCodeResponse = await client.SendAsync(apiPostalCodeRequest);

      var resultResponse = apiPostalCodeResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

      var resultDeserializeObject = JsonConvert.DeserializeObject<TOutput>(resultResponse);

      return resultDeserializeObject;
    }
  }
}
