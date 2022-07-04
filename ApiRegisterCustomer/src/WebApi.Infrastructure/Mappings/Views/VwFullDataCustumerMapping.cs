using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Core.Entities.Views;

namespace WebApi.Infrastructure.Mappings.Views
{
  public class VwFullDataCustumerMapping : IEntityTypeConfiguration<VwFullDataCustomer>
  {
    public void Configure(EntityTypeBuilder<VwFullDataCustomer> entity)
    {
      entity.HasNoKey();
      entity.ToView("VW_FULLDATA_CUSTUMER");

      entity.Property(e => e.Street)
          .HasMaxLength(200)
          .HasColumnName("address")
          .IsUnicode(false);

      entity.Property(e => e.City)
          .HasMaxLength(200)
          .HasColumnName("city")
          .IsUnicode(false);

      entity.Property(e => e.Code)
          .HasMaxLength(200)
          .HasColumnName("code")
          .IsUnicode(false);

      entity.Property(e => e.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("datetime");

      entity.Property(e => e.District)
          .HasMaxLength(200)
          .HasColumnName("district")
          .IsUnicode(false);

      entity.Property(e => e.Name)
          .IsRequired()
          .HasColumnName("name")
          .HasMaxLength(60)
          .IsUnicode(false);

      entity.Property(e => e.PhoneNumber)
            .HasColumnName("phone_number")
            .IsUnicode(false);

      entity.Property(e => e.State)
          .HasMaxLength(4)
          .HasColumnName("state")
          .IsUnicode(false);

      entity.Property(e => e.Status)
          .HasMaxLength(10)
          .HasColumnName("status")
          .IsUnicode(false);

      entity.Property(e => e.TaxId)
          .IsRequired()
          .HasColumnName("tax_id")
          .HasMaxLength(25)
          .IsUnicode(false);
    }
  }
}
