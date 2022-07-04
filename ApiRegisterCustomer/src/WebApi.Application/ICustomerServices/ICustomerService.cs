using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Infrastructure.ExternalServices.DtosExternal;

namespace WebApi.Application.ICustomerServices
{
  public interface ICustomerService
  {
    /// <summary>
    /// Service to add new Customer.
    /// </summary>
    /// <param name="Customer">Object Customer</param>
    /// <returns></returns>
    Task AddCustomer(Customer Customer, PostalCodeDtos fullAddress);

    /// <summary>
    /// Service to get all data with filter.
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="tax_id">document</param>
    /// <param name="created_at">creation date</param>
    /// <returns></returns>
    public Task<IEnumerable<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at);
  }
}
