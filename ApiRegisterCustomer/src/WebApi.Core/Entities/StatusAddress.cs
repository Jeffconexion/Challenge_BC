using System.Collections.Generic;

namespace WebApi.Core.Entities
{
  public class StatusAddress : EntityBase
  {
    public StatusAddress()
    {
      AddressNavigation = new List<Address>();
    }

    public string Status { get; set; }

    public virtual IList<Address> AddressNavigation { get; set; }
  }
}
