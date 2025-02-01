using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartsConfiguration : IEntityTypeConfiguration<Carts>
{
    public void Configure(EntityTypeBuilder<Carts> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.UserId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Date)
            .IsRequired()
            .HasColumnType("date");

        builder
         .Property(x => x.Products)
         .HasColumnType("jsonb")
         .HasConversion(
              x => JsonConvert.SerializeObject(x),
              x => JsonConvert.DeserializeObject<List<Product>>(x)
          );
    }
}
