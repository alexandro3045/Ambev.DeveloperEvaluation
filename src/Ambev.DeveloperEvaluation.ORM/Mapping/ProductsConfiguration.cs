using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Title).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Price).IsRequired().HasMaxLength(10);
        builder.Property(u => u.Descripption).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Category).HasMaxLength(20);

        builder.Property(u => u.Image).HasColumnType("image");


        builder
         .Property(x => x.Rating)
         .HasColumnType("jsonb")
         .HasConversion(
              x => JsonConvert.SerializeObject(x),
              x => JsonConvert.DeserializeObject<Rating>(x)
          );


    }
}
