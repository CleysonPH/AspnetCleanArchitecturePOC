using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.Validators;

namespace ProjectManager.Application.Validators.Users;

public interface ICreateUserValidator : IValidator<CreateUserViewModel>
{ }