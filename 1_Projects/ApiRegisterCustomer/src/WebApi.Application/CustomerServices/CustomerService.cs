using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Application.Dtos;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices.IExternalServices;

namespace WebApi.Application.CustomerServices
{
  public class CustomerService : ICustomerService
  {
    private readonly IRepositoryCustomer _repositoryCustomer;
    private readonly IPostalCodeServices _postalCodeServices;

    public CustomerService(IRepositoryCustomer repositoryCustomer, IPostalCodeServices postalCodeServices)
    {
      _repositoryCustomer = repositoryCustomer;
      _postalCodeServices = postalCodeServices;
    }

    public async Task<ResponseDtos> AddCustomer(Customer customer, string postalCode)
    {
      var fullAddress = await SearchPostalCode(postalCode);

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

    private async Task<Infrastructure.ExternalServices.DtosExternal.PostalCodeDtos> SearchPostalCode(string postalCode)
    {
      var fullAddress = await _postalCodeServices.GetFullAddress(postalCode);

      if (fullAddress?.Status is 400)
      {
        throw new ArgumentException($"{fullAddress.StatusText} {fullAddress.Status}");
      }

      if (fullAddress?.Status is 404)
      {
        throw new ArgumentException($"{fullAddress.StatusText} {fullAddress.Status}");
      }

      return fullAddress;
    }

    public async Task<IEnumerable<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, string created_at)
    {
      var custumerList = await _repositoryCustomer.GetFullDataWithFilter(name, tax_id, created_at);
      return custumerList;
    }
  }
}
