using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;

namespace WebApi.Application.CustomerServices
{
  public class CustomerService : ICustomerService
  {
    private readonly IRepositoryCustomer _repositoryCustomer;

    public CustomerService(IRepositoryCustomer repositoryCustumer)
    {
      _repositoryCustomer = repositoryCustumer;
    }

    public async Task CreateCustumer(Customer Customer)
    {
      await _repositoryCustomer.CreateCustumer(Customer);
    }

    public async Task<IEnumerable<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at)
    {
      var custumerList = await _repositoryCustomer.GetFullDataWithFilter(name, tax_id, created_at);
      return custumerList;
    }
  }
}
