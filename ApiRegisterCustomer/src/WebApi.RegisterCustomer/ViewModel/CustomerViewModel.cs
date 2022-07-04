using System.Text.Json.Serialization;
using WebApi.Core.Entities;

namespace WebApi.RegisterCustomer.ViewModel
{
  public class CustomerViewModel
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tax_id")]
    public string TaxId { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    public static Customer ToEntity(CustomerViewModel customer)
    {
      return new Customer(
          customer.Name,
          customer.TaxId,
          customer.Password,
          customer.PhoneNumber
      );
    }
  }
}


