

using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductsConfiguration : IEntityTypeConfiguration<ProductsItems>
    {
        public void Configure(EntityTypeBuilder<ProductsItems> builder)
        {
            builder
                .ToTable("ProductsItems");

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");


            builder
                .Property(u => u.ProductId);

            builder
                .Property(u => u.Quantity);

            builder
                .HasOne(p => p.Product)
                .WithOne()
                .HasForeignKey<ProductsItems>(b => b.ProductId)
                .IsRequired(false);
        }
    }
}
