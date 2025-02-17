using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartsConfiguration : IEntityTypeConfiguration<Carts>
{
    public void Configure(EntityTypeBuilder<Carts> builder)
    {
        builder
            .ToTable("Carts");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder
            .Property(u => u.UserId)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder
            .HasMany(sc => sc.CartsProductsItemns)
            .WithOne()
            .HasForeignKey(b => b.CartId)
            .HasPrincipalKey(e => e.Id)
            .IsRequired(false);
    }
}
