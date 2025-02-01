using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder
          .Property(x => x.Name)
          .HasColumnType("jsonb")
          .HasConversion(
               x => JsonConvert.SerializeObject(x),
               x => JsonConvert.DeserializeObject<Name>(x)
           );

        builder
          .Property(x => x.Address)
          .HasColumnType("jsonb")
          .HasConversion(
               x => JsonConvert.SerializeObject(x),
               x => JsonConvert.DeserializeObject<Address>(x)
           );

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

    }
}
