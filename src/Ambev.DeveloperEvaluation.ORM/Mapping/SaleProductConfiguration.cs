using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SaleProducts");

        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(sp => sp.Quantity).IsRequired();
        builder.Property(sp => sp.UnitPrice).IsRequired().HasColumnType("numeric(10,2)");
        builder.Property(sp => sp.Discount).IsRequired().HasDefaultValue(0).HasColumnType("numeric(10,2)");
        builder.Property(sp => sp.TotalItemAmount).IsRequired().HasColumnType("numeric(10,2)");

        builder.Property(sp => sp.ProductId).IsRequired(); 
    }
}