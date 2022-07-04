using System;

namespace WebApi.Core.Entities.Views
{
  public partial class VwFullDataCustomer
  {
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string Code { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Status { get; set; }
  }
}
