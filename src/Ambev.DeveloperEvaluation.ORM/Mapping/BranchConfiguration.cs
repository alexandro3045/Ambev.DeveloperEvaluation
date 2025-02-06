using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class BranchConfiguration : IEntityTypeConfiguration<Carts>
{
    public void Configure(EntityTypeBuilder<Carts> builder)
    {
        builder
            .ToTable("Carts");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnType("uuid");

        builder
            .Property(u => u.UserId)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("date");
            
    }
}


