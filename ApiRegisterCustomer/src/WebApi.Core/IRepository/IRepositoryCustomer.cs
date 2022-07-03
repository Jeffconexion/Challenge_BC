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
    /// Register new custumer
    /// </summary>
    /// <param name="custumer">object custumer</param>
    /// <returns></returns>
    Task CreateCustumer(Custumer custumer);


    /// <summary>
    /// Get all data with optional parameters 
    /// </summary>
    /// <param name="name">Name Custumer</param>
    /// <param name="tax_id">Documents</param>
    /// <param name="created_at">Criation Data</param>
    /// <returns></returns>
    Task<IEnumerable<VwFullDataCustumer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at);
  }
}
