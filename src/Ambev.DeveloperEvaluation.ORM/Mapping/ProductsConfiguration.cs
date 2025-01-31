using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Title).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Price).IsRequired().HasMaxLength(10);
        builder.Property(u => u.Descripption).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Category).HasMaxLength(20);
        builder.Property(u => u.Image).HasColumnType("image");
        builder.Property(u => u.Rating).HasColumnType("jsonb");


    }
}
