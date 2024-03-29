﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;
using WebApi.Core.Queries;
using WebApi.Infrastructure.Context;

namespace WebApi.Infrastructure.Repository
{
  public class RepositoryCustomer : IRepositoryCustomer
  {
    private readonly DataContext _context;

    public RepositoryCustomer(DataContext context)
    {
      _context = context;
    }
    public async Task AddCustomer(Customer Customer, Address address)
    {
      var statusAddress = AddStatusAddress(address);

      address.IdCustomer = Customer.Id;
      address.IdStatusAddress = statusAddress.Id;

      try
      {
        await _context.AddRangeAsync(Customer, statusAddress, address);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException ex)
      {
        throw ex;
      }
    }

    public async Task<List<VwFullDataCustomer>> GetFullDataWithFilter(string name, string tax_id, string created_at)
    {
      List<VwFullDataCustomer> custumerList;
      if (AllParametrsIsEmpty(name, tax_id, created_at))
      {
        custumerList = await _context.VwFullDataCustomers
                                         .AsNoTracking()
                                         .ToListAsync();
        return custumerList;
      }

      custumerList = await _context.VwFullDataCustomers
                                         .AsNoTracking()
                                         .Where(CustomerQuerys.GetFilterSpecificParameters(name, tax_id, created_at))
                                         .ToListAsync();
      return custumerList;
    }

    private StatusAddress AddStatusAddress(Address address)
    {
      StatusAddress statusAddress = new StatusAddress();

      if (string.IsNullOrWhiteSpace(address.Code) is true)
      {
        statusAddress.Status = "PENDING";
      }

      if (string.IsNullOrWhiteSpace(address.Code) is false)
      {
        statusAddress.Status = "APPROVED";
      }

      return statusAddress;
    }

    private static bool AllParametrsIsEmpty(string name, string tax_id, string created_at)
    {
      return string.IsNullOrWhiteSpace(name) is true &&
             string.IsNullOrWhiteSpace(tax_id) is true &&
             string.IsNullOrWhiteSpace(created_at) is true;
    }

  }
}
