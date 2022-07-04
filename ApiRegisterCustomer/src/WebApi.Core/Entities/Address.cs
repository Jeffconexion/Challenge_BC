using System;

namespace WebApi.Core.Entities
{
  public class Address : EntityBase
  {
    public Guid? IdCustumer { get; set; }
    public Guid? IdStatusAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Code { get; set; }

    public virtual Customer IdCustumerNavigation { get; set; }
    public virtual StatusAddress IdStatusAddressNavigation { get; set; }
  }
}
