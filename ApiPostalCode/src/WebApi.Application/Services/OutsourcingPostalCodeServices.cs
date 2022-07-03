using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Application.Config;
using WebApi.Application.Dtos;
using WebApi.Application.IServices;

namespace WebApi.Application.Services
{
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

    // public OutsourcingPostalCodeServices(){ }


    /// <summary>
    /// Get Full postal code.
    /// </summary>
    /// <param name="postalcode">postal code</param>
    /// <returns>return object postal code.</returns>
    public async Task<PostalCodeDtos> SearchPostalCode(string postalcode)
    {
      try
      {
        Url = _zipsSettings.Widenet + postalcode;
        await HttpRequestPostalCode();
      }
      catch (Exception ex)
      {
        throw new ArgumentException("The service is currently unavailable. Please contact support:" + ex);
      }
      return JsonConvert.DeserializeObject<PostalCodeDtos>(FullPostalCode);
    }

    /// <summary>
    /// Create a new Request to get postal code.
    /// </summary>
    /// <returns></returns>
    private async Task HttpRequestPostalCode()
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
      request.AutomaticDecompression = DecompressionMethods.GZip;

      using (var response = await request.GetResponseAsync())
      using (Stream stream = response.GetResponseStream())
      using (StreamReader reader = new StreamReader(stream))
      {
        FullPostalCode = reader.ReadToEnd();
      }
    }

  }
}
