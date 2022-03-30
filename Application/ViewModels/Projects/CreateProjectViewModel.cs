namespace ProjectManager.Application.ViewModels.Projects;

public class CreateProjectViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ResponsableId { get; set; }
    public int LeaderId { get; set; }
}
