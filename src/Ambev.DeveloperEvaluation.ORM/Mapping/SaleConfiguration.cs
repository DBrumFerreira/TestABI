using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()"); 

        builder.Property(s => s.SaleNumber).IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.SaleDate).IsRequired().HasColumnType("timestamp"); 
        builder.Property(s => s.CustomerName).IsRequired().HasMaxLength(100); 
        builder.Property(s => s.Branch).IsRequired().HasMaxLength(100);
        builder.Property(s => s.TotalAmount).IsRequired().HasColumnType("numeric(10,2)"); 
        builder.Property(s => s.IsCancelled).IsRequired().HasDefaultValue(false); 
    }
}