using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappers;

public interface IProjectMapper
{
    Project ToDomain(CreateProjectViewModel createProjectViewModel);
    DetailProjectViewModel ToDetailViewModel(Project project);
}