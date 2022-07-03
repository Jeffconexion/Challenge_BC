using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Infrastructure.Repository;

namespace WebApi.Application.CustomerServices
{
  public class CustumerService : ICustumerService
  {
    private readonly RepositoryCustumer _repositoryCustumer;

    public CustumerService(RepositoryCustumer repositoryCustumer)
    {
      _repositoryCustumer = repositoryCustumer;
    }

    public async Task CreateCustumer(Custumer custumer)
    {
      await _repositoryCustumer.CreateCustumer(custumer);
    }

    public async Task<IEnumerable<VwFullDataCustumer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {
      var custumerList = await _repositoryCustumer.GetFullDataWithFilter(name, tax_id, created_at);
      return custumerList;
    }
  }
}
