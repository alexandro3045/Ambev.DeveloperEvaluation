using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesCartsConfiguration : IEntityTypeConfiguration<SalesCarts>
{
    public void Configure(EntityTypeBuilder<SalesCarts> builder)
    {
        builder
            .ToTable("SalesCarts");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnType("uuid");

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("CreatedAt");

        builder
            .Property(u => u.UpdatedAt)
            .IsRequired()
            .HasColumnType("UpdatedAt");

        builder
            .Property(u => u.Customer)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(u => u.TotalSales)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .HasOne(Branch => Branch.Branch)
            .WithMany()
            .HasForeignKey(b => b .Id);

        builder
         .Property(x => x.Products)
         .HasColumnType("jsonb")
         .HasConversion(
              x => JsonConvert.SerializeObject(x),
              x => JsonConvert.DeserializeObject<List<Product>>(x)
          );

        builder
            .Property(u => u.Quantities)
            .HasColumnType("int");

        builder
            .Property(u => u.UnitPrice)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(u => u.Discounts)
            .IsRequired()
            .HasMaxLength(3);

        builder
            .Property(u => u.TotalAmountItem)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(u => u.Canceled)
            .IsRequired()
            .HasMaxLength(10);
    }
}