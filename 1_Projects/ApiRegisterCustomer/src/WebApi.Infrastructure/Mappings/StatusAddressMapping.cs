using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Core.Entities;

namespace WebApi.Infrastructure.Mappings
{
  class StatusAddressMapping : IEntityTypeConfiguration<StatusAddress>
  {
    public void Configure(EntityTypeBuilder<StatusAddress> entity)
    {
      entity.ToTable("TB_STATUS_ADDRESS");
      entity.HasKey(e => e.Id);
      entity.Property(e => e.Id)
        .ValueGeneratedNever();

      entity.Property(e => e.Status)
          .HasMaxLength(10)
          .HasColumnName("status")
          .IsUnicode(false);
    }
  }
}
