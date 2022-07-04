using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;

namespace WebApi.Core.IRepository
{
  public interface IRepositoryCustomer
  {

    /// <summary>
    /// Register new Customer
    /// </summary>
    /// <param name="Customer">object Customer</param>
    /// <returns></returns>
    Task AddCustomer(Customer Customer, Address address);


    /// <summary>
    /// Get all data with optional parameters 
    /// </summary>
    /// <param name="name">Name Customer</param>
    /// <param name="tax_id">Documents</param>
    /// <param name="created_at">Criation Data</param>
    /// <returns></returns>
    Task<List<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at);
  }
}
