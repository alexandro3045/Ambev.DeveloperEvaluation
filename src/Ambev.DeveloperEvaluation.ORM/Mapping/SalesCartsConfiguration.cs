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
            .Property(u => u.SalesNumber)
            .IsRequired()
            .HasColumnType("integer");

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder
            .Property(u => u.UpdatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder
            .Property(u => u.UserId)
            .IsRequired();

        builder
            .HasOne(sc => sc.User)
            .WithOne()
            .HasForeignKey<SalesCarts>(b => b.UserId)
            .IsRequired(false);

        builder
            .Property(u => u.TotalSalesAmount)
            .IsRequired()
            .HasMaxLength(10);

        builder
            .Property(u => u.BranchId)
            .HasColumnType("uuid");

        builder
            .HasOne(sc => sc.Branch)
            .WithOne()
            .HasForeignKey<SalesCarts>(b => b.BranchId)
            .IsRequired(false);

        builder
            .Property(u => u.CartId)
            .HasColumnType("uuid");

        builder
            .HasOne(sc => sc.Carts)
            .WithOne()
            .HasForeignKey<SalesCarts>(b => b.CartId)
            .IsRequired(false);

        builder
            .Property(u => u.Quantities)
            .HasColumnType("int");

        builder
            .Property(u => u.Canceled)
            .IsRequired()
            .HasMaxLength(10);
    }
}