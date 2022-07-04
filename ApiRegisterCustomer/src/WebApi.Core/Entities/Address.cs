using System;

namespace WebApi.Core.Entities
{
  public class Address : EntityBase
  {
    public Guid IdCustomer { get; set; }
    public Guid IdStatusAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Code { get; set; }

    public virtual Customer CustomerNavigation { get; set; }
    public virtual StatusAddress StatusAddressNavigation { get; set; }
  }
}
