using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.Context;

namespace WebApi.Infrastructure.Repository
{
  public class RepositoryCustomer : IRepositoryCustomer
  {
    private readonly DataContext _context;

    public RepositoryCustomer(DataContext context)
    {
      _context = context;
    }

    public async Task AddCustomer(Customer Customer, Address address)
    {
      var statusAddress = AddStatusAddress(address);

      address.IdCustomer = Customer.Id;
      address.IdStatusAddress = statusAddress.Id;

      try
      {
        await _context.AddRangeAsync(Customer, statusAddress, address);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException ex)
      {
        throw ex;
      }
    }    

    public async Task<List<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {
      List<VwFullDataCustomer> custumerList = await _context.VwFullDataCustomers
                                 .AsNoTracking()
                                 .Where(c => c.Name.Equals(name) || c.TaxId.Equals(tax_id))
                                 .ToListAsync();
      return custumerList;
    }

    private StatusAddress AddStatusAddress(Address address)
    {
      StatusAddress statusAddress = new StatusAddress();

      if (address.Code is null)
      {
        statusAddress.Status = "PENDING";
      }

      if (address.Code is not null)
      {
        statusAddress.Status = "APPROVED";
      }

      return statusAddress;
    }
  }
}
