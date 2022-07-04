using System;
using System.Collections.Generic;

namespace WebApi.Core.Entities
{
  public class Customer : EntityBase
  {
    public Customer()
    {
      AddressNavigation = new List<Address>();
    }

    public Customer(string name, string taxId, string password, string phoneNumber)
    {
      Name = name;
      TaxId = taxId;
      Password = password;
      PhoneNumber = phoneNumber;
      AddressNavigation = new List<Address>();
    }

    public string Name { get; set; }
    public string TaxId { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? CreatedAt { get; set; }

    public virtual IList<Address> AddressNavigation { get; set; }

  }
}
