using System;
using System.Collections.Generic;

namespace WebApi.Core.Entities
{
  public class Custumer : EntityBase
  {
    public Custumer()
    {
      AddressNavigation = new List<Address>();
    }

    public string Name { get; set; }
    public string TaxId { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? created_at { get; set; }

    public virtual IList<Address> AddressNavigation { get; set; }

  }
}
