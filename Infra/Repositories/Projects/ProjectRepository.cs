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

    public Project Add(Project entity)
    {
        var projectEntity = ProjectEntity.Of(entity);
        _context.Projects.Add(projectEntity);
        _context.SaveChanges();
        return projectEntity.ToDomain();
    }

    public void Delete(Project entity)
    {
        _context.Projects.Remove(ProjectEntity.Of(entity));
        _context.SaveChanges();
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

    public Project Update(Project entity)
    {
        var projectEntity = ProjectEntity.Of(entity);
        _context.Projects.Update(projectEntity);
        _context.SaveChanges();
        return projectEntity.ToDomain();
    }
}