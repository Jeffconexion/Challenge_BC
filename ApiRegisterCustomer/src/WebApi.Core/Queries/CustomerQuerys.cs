using System;
using System.Linq.Expressions;
using WebApi.Core.Entities.Views;

namespace WebApi.Core.Queries
{
  public static class CustomerQuerys
  {
    public static Expression<Func<VwFullDataCustomer, bool>> GetAll(string name, string tax_id, DateTime created_at)
    {
      return c => c.Name.Equals(name) || c.TaxId.Equals(tax_id) || c.CreatedAt == created_at;
    }
  }
}
