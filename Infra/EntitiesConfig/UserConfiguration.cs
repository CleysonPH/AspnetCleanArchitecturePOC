using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infra.EntitiesConfig;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(user => user.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(user => user.Password)
            .HasColumnName("password")
            .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(user => user.Role)
            .HasColumnName("role")
            .HasColumnType("int")
            .IsRequired();

        builder.HasIndex(user => user.Email)
            .IsUnique();
    }
}