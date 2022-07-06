using System.Text.Json.Serialization;
using WebApi.Core.Entities;

namespace WebApi.Application.Dtos
{
  public class ResponseDtos
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tax_id")]
    public string TaxId { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("address")]
    public AddressDtos Address { get; set; }

    public ResponseDtos(Customer customer, Address address)
    {
      Name = customer.Name;
      TaxId = customer.TaxId;
      PhoneNumber = customer.PhoneNumber;
      CreatedAt = customer.CreatedAt.ToString();
      Address = new AddressDtos(address);
      Status = (address.Code is null) ? "PENDING" : "APPROVED";
    }

    public ResponseDtos()
    {

    }
  }
}
