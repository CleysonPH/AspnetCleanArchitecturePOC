using ProjectManager.Application.Mappers;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Core.Exceptions;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infra.Mappers.Projects;

public class ProjectMapper : IProjectMapper
{
    private readonly IUserRepository _userRepository;

    public ProjectMapper(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public DetailProjectViewModel ToDetailViewModel(Project project)
    {
        return new DetailProjectViewModel
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            StartedAt = project.StartedAt,
            ConcludedAt = project.ConcludedAt,
            Status = (int)project.Status,
            ResponsableId = project.Responsable.Id,
            LeaderId = project.Leader.Id
        };
    }

    public Project ToDomain(CreateProjectViewModel createProjectViewModel)
    {
        var responsable = _userRepository.GetById(createProjectViewModel.ResponsableId);
        var leader = _userRepository.GetById(createProjectViewModel.LeaderId);

        if (responsable is null)
        {
            throw new UserNotFoundException();
        }

        if (leader is null)
        {
            throw new UserNotFoundException();
        }

        return new Project(
            createProjectViewModel.Name,
            responsable,
            leader,
            Status.Created,
            createProjectViewModel.Description
        );
    }
}