using System;

namespace WebApi.Core.Entities.Views
{
  public partial class VW_FULLDATA_CUSTUMER
  {
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Status { get; set; }
  }
}
