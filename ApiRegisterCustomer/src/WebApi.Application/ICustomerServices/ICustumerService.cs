using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;

namespace WebApi.Application.ICustomerServices
{
  public interface ICustumerService
  {
    /// <summary>
    /// Service to add new custumer.
    /// </summary>
    /// <param name="custumer">Object custumer</param>
    /// <returns></returns>
    Task CreateCustumer(Custumer custumer);

    /// <summary>
    /// Service to get all data with filter.
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="tax_id">document</param>
    /// <param name="created_at">creation date</param>
    /// <returns></returns>
    public Task<IEnumerable<VwFullDataCustumer>> GetFullDataWithFilter(string name, string tax_id, DateTime created_at);
  }
}
