using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public User Responsable { get; set; }
    public User Leader { get; set; }
    public Status Status { get; set; }

    public Project(
        string name,
        User responsable,
        User leader,
        Status status,
        DateTime createdAt,
        string? description = null,
        DateTime? startedAt = null,
        DateTime? concludedAt = null)
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        StartedAt = startedAt;
        ConcludedAt = concludedAt;
        Responsable = responsable;
        Leader = leader;
        Status = status;
        ValidadeData();
    }

    public Project(
        int id,
        string name,
        User responsable,
        User leader,
        Status status,
        string? description = null,
        DateTime? startedAt = null,
        DateTime? concludedAt = null)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
        StartedAt = startedAt;
        ConcludedAt = concludedAt;
        Responsable = responsable;
        Leader = leader;
        Status = status;
        ValidadeData();
    }

    private void ValidadeData()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name is required");

        if (Responsable == null)
            throw new ArgumentException("Responsable is required");

        if (Leader == null)
            throw new ArgumentException("Leader is required");

        if (Status == default)
            throw new ArgumentException("Status is required");

        if (CreatedAt == default)
            throw new ArgumentException("CreatedAt is required");
    }
}