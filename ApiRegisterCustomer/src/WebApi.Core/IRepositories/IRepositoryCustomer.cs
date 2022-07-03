using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Entities.Views;

namespace WebApi.Core.IRepositories
{
  public interface IRepositoryCustomer
  {
    /// <summary>
    /// Get all data with optional parameters 
    /// </summary>
    /// <param name="name">Name Custumer</param>
    /// <param name="tax_id">Documents</param>
    /// <param name="created_at">Criation Data</param>
    /// <returns></returns>
    Task<IEnumerable<VW_FULLDATA_CUSTUMER>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at);
  }
}
