using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;

namespace WebApi.Infrastructure.Repository
{
  public class RepositoryCustumer : IRepositoryCustomer
  {
    public async Task<IEnumerable<VwFullDataCustumer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {
      throw new NotImplementedException();
    }
  }
}
