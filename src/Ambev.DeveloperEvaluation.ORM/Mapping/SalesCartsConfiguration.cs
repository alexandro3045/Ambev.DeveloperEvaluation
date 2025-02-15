using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("date");
        
        builder
            .Property(u => u.UpdatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder
            .Property(u => u.Customer)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(u => u.TotalSales)
            .IsRequired()
            .HasMaxLength(10);

            builder
                .HasOne(sc => sc.Branch)
                .WithMany()
                .HasForeignKey(b => b.Id);

            builder
            .HasOne(sc => sc.Carts)
            .WithOne()
            .HasForeignKey<Carts>(b => b.Id);


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