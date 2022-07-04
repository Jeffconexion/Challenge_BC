using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Core.Entities;

namespace WebApi.Infrastructure.Mappings
{
  public class CustumerMapping : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
      entity.ToTable("TB_CUSTUMER");
      entity.Property(e => e.Id).ValueGeneratedNever();
      entity.HasKey(e => e.Id);

      entity.Property(e => e.Name)
          .IsRequired()
          .HasColumnName("name")
          .HasMaxLength(60)
          .IsUnicode(false);

      entity.Property(e => e.PhoneNumber)
        .HasColumnName("phone_number")
        .IsUnicode(false);

      entity.Property(e => e.TaxId)
          .IsRequired()
          .HasColumnName("tax_id")
          .HasMaxLength(25)
          .IsUnicode(false);

      entity.Property(e => e.Password)
          .IsRequired()
          .HasColumnName("password")
          .HasMaxLength(30)
          .IsUnicode(false);

      entity.Property(e => e.CreatedAt)
          .HasColumnType("datetime")
          .HasColumnName("created_at")
          .HasDefaultValueSql("(getdate())");
    }
  }
}
