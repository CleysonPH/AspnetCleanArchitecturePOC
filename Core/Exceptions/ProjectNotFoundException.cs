namespace ProjectManager.Core.Exceptions;

public class ProjectNotFoundException : EntityNotFoundException
{
    public ProjectNotFoundException() : base("Project not found")
    { }
}
