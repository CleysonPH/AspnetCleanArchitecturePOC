using ProjectManager.Core.Repositories;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Repositories.Projects;

public interface IProjectRepository : ICrudRepository<Project, int>
{ }
