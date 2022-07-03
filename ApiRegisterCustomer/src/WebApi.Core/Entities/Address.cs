using System;

namespace WebApi.Core.Entities
{
  public class Address : EntityBase
  {
    public Guid? id_custumer { get; set; }
    public Guid? id_status_address { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Code { get; set; }

    public virtual Custumer id_custumerNavigation { get; set; }
    public virtual StatusAddress id_status_addressNavigation { get; set; }
  }
}
