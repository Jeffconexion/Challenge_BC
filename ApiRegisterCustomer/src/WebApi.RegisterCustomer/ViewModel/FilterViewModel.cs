using System.Text.Json.Serialization;

namespace WebApi.RegisterCustomer.ViewModel
{
  public class FilterViewModel
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tax_id")]
    public string TaxId { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
  }
}
