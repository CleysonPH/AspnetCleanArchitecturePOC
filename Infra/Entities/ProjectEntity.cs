using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infra.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime ConcludedAt { get; set; }
    public UserEntity Responsable { get; set; } = null!;
    public UserEntity Leader { get; set; } = null!;
    public Status Status { get; set; }
    public int ResponsableId { get; set; }
    public int LeaderId { get; set; }

    public static ProjectEntity Of(Project project)
    {
        return new ProjectEntity
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            StartedAt = project.StartedAt,
            ConcludedAt = project.ConcludedAt,
            Responsable = UserEntity.Of(project.Responsable),
            Leader = UserEntity.Of(project.Leader),
            Status = project.Status,
            ResponsableId = project.Responsable.Id,
            LeaderId = project.Leader.Id
        };
    }
    // return new ProjectEntity(
    //     project.Id,
    //     project.Name,
    //     project.CreatedAt,
    //     project.StartedAt,
    //     project.ConcludedAt,
    //     UserEntity.Of(project.Responsable),
    //     UserEntity.Of(project.Leader),
    //     project.Status,
    //     project.Responsable.Id,
    //     project.Leader.Id,
    //     project.Description);
    // }

    public Project ToDomain()
    {
        return new Project(
            Id,
            Name,
            StartedAt,
            ConcludedAt,
            Responsable.ToDomain(),
            Leader.ToDomain(),
            Status,
            Description);
    }
}
