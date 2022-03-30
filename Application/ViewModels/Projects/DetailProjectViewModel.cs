namespace ProjectManager.Application.ViewModels.Projects;

public class DetailProjectViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public int Status { get; set; }
    public int ResponsableId { get; set; }
    public int LeaderId { get; set; }
}
