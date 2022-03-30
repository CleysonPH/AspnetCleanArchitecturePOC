using ProjectManager.Application.Mappers;
using ProjectManager.Application.Repositories.Projects;
using ProjectManager.Application.Validators.Projects;
using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Core.UseCases;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.UseCases.Projects;

public class CreateProjectUseCase : IUseCase<CreateProjectViewModel, DetailProjectViewModel>
{
    private readonly IProjectMapper _mapper;
    private readonly IProjectRepository _repository;
    private readonly ICreateProjectValidator _validator;

    public CreateProjectUseCase(
        IProjectMapper mapper,
        IProjectRepository repository,
        ICreateProjectValidator validator)
    {
        _mapper = mapper;
        _repository = repository;
        _validator = validator;
    }

    public DetailProjectViewModel Execute(CreateProjectViewModel input)
    {
        _validator.Validate(input);

        var project = _mapper.ToDomain(input);
        project.CreatedAt = DateTime.UtcNow;
        project.Status = Status.Created;

        project = _repository.Add(project);

        return _mapper.ToDetailViewModel(project);
    }
}
