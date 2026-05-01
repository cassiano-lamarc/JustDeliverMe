using JustDeliverMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustDeliverMe.Infra.Mappings;

public class PointsMap : IEntityTypeConfiguration<Points>
{
    public void Configure(EntityTypeBuilder<Points> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.TenantId).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Code).HasMaxLength(20).IsRequired();

        builder
           .HasIndex(p => new { p.TenantId, p.Code })
           .IsUnique()
           .HasDatabaseName("uq_points_tenant_code");
    }
}
