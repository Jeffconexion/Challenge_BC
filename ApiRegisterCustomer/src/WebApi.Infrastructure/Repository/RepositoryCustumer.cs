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
  public class RepositoryCustumer : IRepositoryCustomer
  {
    private readonly DataContext _context;

    public RepositoryCustumer(DataContext context)
    {
      _context = context;
    }

    public async Task CreateCustumer(Custumer custumer)
    {
      await _context.Customers.AddAsync(custumer);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<VwFullDataCustumer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {
      var custumerList = await _context.VwFullDataCustumers
                                 .AsNoTracking()
                                 .Where(c => c.Name.Equals(name) || c.TaxId.Equals(tax_id) || c.CreatedAt == created_at)
                                 .SingleOrDefaultAsync();

      return (IEnumerable<VwFullDataCustumer>)custumerList;
    }
  }
}
