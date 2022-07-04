using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Application.Config;
using WebApi.Application.Dtos;
using WebApi.Application.IServices;

namespace WebApi.Application.Services
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 03/07/2022
  /// 
  /// OutsourcingPostalCodeServices is the most important component
  /// of our application. It makes requests to the external api, with the
  /// aim of obtaining the zip code.
  /// 
  /// ~~> Be careful when modifying this class!
  /// </summary>
  public class OutsourcingPostalCodeServices : IOutsourcingPostalCodeServices
  {
    private string FullPostalCode { get; set; }
    private string Url { get; set; }
    private readonly ZipsSettings _zipsSettings;

    public OutsourcingPostalCodeServices(IOptions<ZipsSettings> zipsSettings)
    {
      _zipsSettings = zipsSettings.Value;
      FullPostalCode = string.Empty;
      Url = string.Empty;
    }

    /// <summary>
    /// Get Full postal code.
    /// </summary>
    /// <param name="postalcode">postal code</param>
    /// <returns>return object postal code.</returns>
    public async Task<PostalCodeDtos> SearchPostalCode(string postalcode)
    {
      try
      {
        Url = new StringBuilder().Append(_zipsSettings.Widenet).Append(postalcode).ToString();
        await HttpRequestPostalCode();
      }
      catch (Exception)
      {
        throw new ArgumentException("The service is currently unavailable. Please contact support!");
      }
      return JsonConvert.DeserializeObject<PostalCodeDtos>(FullPostalCode);
    }

    /// <summary>
    /// Create a new Request to get postal code.
    /// </summary>
    /// <returns></returns>
    private async Task HttpRequestPostalCode()
    {
      HttpClient cliente = new HttpClient();
      FullPostalCode = await cliente.GetStringAsync(Url);
    }
  }
}
