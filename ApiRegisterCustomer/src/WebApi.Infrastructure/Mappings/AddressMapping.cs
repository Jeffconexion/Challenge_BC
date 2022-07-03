using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Core.Entities;

namespace WebApi.Infrastructure.Mappings
{
  public class AddressMapping : IEntityTypeConfiguration<Address>
  {
    public void Configure(EntityTypeBuilder<Address> entity)
    {
      entity.ToTable("TB_ADDRESS");
      entity.Property(e => e.Id).ValueGeneratedNever();
      entity.HasKey(e => e.Id);

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

      entity.Property(e => e.District)
          .HasMaxLength(200)
          .HasColumnName("district")
          .IsUnicode(false);

      entity.Property(e => e.State)
          .HasMaxLength(4)
          .HasColumnName("state")
          .IsUnicode(false);

      entity.HasOne(d => d.IdCustumerNavigation)
          .WithMany(p => p.AddressNavigation)
          .HasForeignKey(d => d.IdCustumer);

      entity.HasOne(d => d.IdStatusAddressNavigation)
          .WithMany(p => p.AddressNavigation)
          .HasForeignKey(d => d.IdStatusAddress);
    }
  }
}
