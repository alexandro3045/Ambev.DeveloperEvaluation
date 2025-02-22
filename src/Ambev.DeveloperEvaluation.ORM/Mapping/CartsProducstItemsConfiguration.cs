using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartsProducstItemsConfiguration : IEntityTypeConfiguration<CartsProductsItems>
{
    public void Configure(EntityTypeBuilder<CartsProductsItems> builder)
    {
        builder
            .ToTable("CartsProductsItems");

        builder
             .HasKey(t => new { t.Id });

        builder
            .Property(u => u.Id)
            .HasColumnType("uuid");

        builder
            .Property(u => u.Quantity)
            .IsRequired()
            .HasColumnType("int");

        builder
            .Property(u => u.CartId)
            .IsRequired()
            .HasColumnType("uuid");

        builder
            .HasOne(p => p.Cart)
            .WithOne()
            .HasForeignKey<Carts>(b => b.Id)
            .IsRequired(false);

        builder
            .Property(u => u.ProductId)
            .IsRequired()
            .HasColumnType("uuid");

        builder
            .HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(b => b.ProductId)
            .IsRequired(false);

        builder.Property(u => u.UnitPrice)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(u => u.TotalAmountItem)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(u => u.Discounts)
            .IsRequired()
            .HasMaxLength(10);
    }
}
