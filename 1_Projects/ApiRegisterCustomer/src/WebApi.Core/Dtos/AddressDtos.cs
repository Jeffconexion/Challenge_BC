using System.Text.Json.Serialization;
using WebApi.Core.Entities;

namespace WebApi.Application.Dtos
{
  public class AddressDtos
  {
    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("district")]
    public string District { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    public AddressDtos(Address address)
    {
      State = address.State;
      City = address.City;
      District = address.District;
      Street = address.Street;
      PostalCode = address.Code;
    }
  }


}
