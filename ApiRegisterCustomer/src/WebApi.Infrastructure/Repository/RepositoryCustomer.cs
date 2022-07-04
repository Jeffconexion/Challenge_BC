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

    public async Task CreateCustumer(Customer Customer)
    {
      await _context.Customers.AddAsync(Customer);
      await _context.SaveChangesAsync();
    }

    public async Task<List<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {

      List<VwFullDataCustomer> custumerList = await _context.VwFullDataCustomers
                                 .AsNoTracking()
                                 .Where(c => c.Name.Equals(name) || c.TaxId.Equals(tax_id))
                                 .ToListAsync();

      return custumerList;
    }
  }
}
