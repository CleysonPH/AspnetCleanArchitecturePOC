using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Infra.Entities;

namespace ProjectManager.Infra.EntitiesConfig;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(project => project.Id);

        builder.Property(project => project.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(project => project.Description)
            .HasColumnName("description")
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");

        builder.Property(project => project.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(project => project.StartedAt)
            .HasColumnName("started_at")
            .HasColumnType("timestamp");

        builder.Property(project => project.ConcludedAt)
            .HasColumnName("concluded_at")
            .HasColumnType("timestamp");

        builder.Property(project => project.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(project => project.Responsable)
            .WithMany()
            .HasForeignKey(project => project.ResponsableId);

        builder.HasOne(project => project.Leader)
            .WithMany()
            .HasForeignKey(project => project.LeaderId);
    }
}