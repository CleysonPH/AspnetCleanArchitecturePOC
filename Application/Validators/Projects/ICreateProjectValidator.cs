using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Core.Validators;

namespace ProjectManager.Application.Validators.Projects;

public interface ICreateProjectValidator : IValidator<CreateProjectViewModel>
{ }