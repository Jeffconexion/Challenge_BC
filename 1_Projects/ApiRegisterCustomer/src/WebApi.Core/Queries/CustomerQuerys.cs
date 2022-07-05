using System;
using System.Linq.Expressions;
using WebApi.Core.Entities.Views;

namespace WebApi.Core.Queries
{
  public static class CustomerQuerys
  {
    public static DateTime DateInitial { get; set; }
    public static DateTime DateEnd { get; set; }

    public static Expression<Func<VwFullDataCustomer, bool>> GetFilterSpecificParameters(string name, string tax_id, string created_at)
    {
      var teste = string.IsNullOrWhiteSpace(created_at);

      if (string.IsNullOrWhiteSpace(created_at) is true)
      {
        return c => c.Name.Equals(name) || c.TaxId.Equals(tax_id);
      }

      FormatDateToFilter(created_at);
      return c => c.Name.Equals(name) || c.TaxId.Equals(tax_id) || c.CreatedAt >= DateInitial && c.CreatedAt <= DateEnd;
    }

    private static void FormatDateToFilter(string created_at)
    {
      DateInitial = DateTime.Parse(Convert.ToDateTime(created_at).ToString("dd-MM-yyyy"));
      DateEnd = DateInitial.AddMinutes(1439);
    }
  }
}
