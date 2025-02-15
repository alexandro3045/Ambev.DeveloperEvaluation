using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder
            .ToTable("Branch");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnType("uuid");

        builder.Property(u => u.Descripption)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("date");

        builder
            .Property(u => u.UpdatedAt)
            .IsRequired()
            .HasColumnType("date");

    }
}


