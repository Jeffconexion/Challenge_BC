using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.Dtos;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices.DtosExternal;

namespace WebApi.Application.CustomerServices
{
  public class CustomerService : ICustomerService
  {
    private readonly IRepositoryCustomer _repositoryCustomer;

    public CustomerService(IRepositoryCustomer repositoryCustumer)
    {
      _repositoryCustomer = repositoryCustumer;
    }

    public async Task<ResponseDtos> AddCustomer(Customer customer, PostalCodeDtos fullAddress)
    {

      var address = new Address()
      {
        State = fullAddress?.State,
        City = fullAddress?.City,
        District = fullAddress?.District,
        Street = fullAddress?.Address,
        Code = fullAddress?.Code
      };

      await _repositoryCustomer.AddCustomer(customer, address);

      var response = new ResponseDtos(customer, address);

      return response;
    }

    public async Task<IEnumerable<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, string created_at)
    {
      var custumerList = await _repositoryCustomer.GetFullDataWithFilter(name, tax_id, created_at);
      return custumerList;
    }
  }
}
