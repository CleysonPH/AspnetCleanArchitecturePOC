using ProjectManager.Application.Repositories.Projects;
using ProjectManager.Domain.Entities;
using ProjectManager.Infra.Contexts;
using ProjectManager.Infra.Entities;

namespace ProjectManager.Infra.Repositories.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly SqliteContext _context;

    public ProjectRepository(SqliteContext context)
    {
        _context = context;
    }

    public void Add(Project entity)
    {
        _context.Projects.Add(ProjectEntity.Of(entity));
    }

    public void Delete(Project entity)
    {
        _context.Projects.Remove(ProjectEntity.Of(entity));
    }

    public bool Exists(int id)
    {
        return _context.Projects.Any(p => p.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects.ToList().Select(p => p.ToDomain()).AsEnumerable();
    }

    public Project? GetById(int id)
    {
        return _context.Projects.Find(id)?.ToDomain();
    }

    public void Update(Project entity)
    {
        _context.Projects.Update(ProjectEntity.Of(entity));
    }
}