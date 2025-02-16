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
            .HasKey(t => new { t.Id } );

        builder
            .HasAlternateKey(t => new { t.Id, t.ProductId });

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
            .HasForeignKey<Carts>(b => b.Id);

        builder
            .Property(u => u.ProductId)
            .IsRequired()
            .HasColumnType("uuid");

        builder
            .HasOne(p => p.Product)
            .WithOne()
            .HasForeignKey<Product>(b => b.Id);
    }
}