using Microsoft.EntityFrameworkCore;
using WebApi.Core.Entities;
using WebApi.Core.Entities.Views;
using WebApi.Infrastructure.Mappings;
using WebApi.Infrastructure.Mappings.Views;

namespace WebApi.Infrastructure.Context
{
  public class DataContext : DbContext
  {
    public virtual DbSet<Address> Adresses { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<StatusAddress> StatusAdresses { get; set; }
    public virtual DbSet<VwFullDataCustomer> VwFullDataCustomers { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AddressMapping());
      modelBuilder.ApplyConfiguration(new CustumerMapping());
      modelBuilder.ApplyConfiguration(new StatusAddressMapping());
      modelBuilder.ApplyConfiguration(new VwFullDataCustumerMapping());
    }
  }
}
