using ProjectManager.Application.Validators.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.Constraints;
using ProjectManager.Core.Exceptions;
using ProjectManager.Infra.Constraints;

namespace ProjectManager.Infra.Validators.Users;

public class CreateUserValidator : ICreateUserValidator
{
    private ICollection<IConstraint> _constraints;
    private ValidationException _validationException;

    public CreateUserValidator()
    {
        _constraints = new List<IConstraint>();
        _validationException = new ValidationException();
    }

    public void Validate(CreateUserViewModel createUserViewModel)
    {
        AddConstraints(createUserViewModel);

        _constraints.ToList().ForEach(c => c.Execute(_validationException));
        if (_validationException.HasErrors())
        {
            throw _validationException;
        }
    }

    private void AddConstraints(CreateUserViewModel createUserViewModel)
    {
        _constraints.Add(
            new IsNotNullConstraint<string>(
                createUserViewModel.Name, "name", "name is null"));
        _constraints.Add(
            new IsNotEmptyConstraint(
                createUserViewModel.Name, "name", "name is empty"));

        _constraints.Add(
            new IsNotNullConstraint<string>(
                createUserViewModel.Email, "email", "email is null"));
        _constraints.Add(
            new IsNotEmptyConstraint(
                createUserViewModel.Email, "email", "email is empty"));
        _constraints.Add(
            new IsEmailConstraint(
                createUserViewModel.Email, "email", "email is not valid"));

        _constraints.Add(
            new IsNotNullConstraint<string>(
                createUserViewModel.Password, "password", "password is null"));
        _constraints.Add(
            new IsNotEmptyConstraint(
                createUserViewModel.Password, "password", "password is empty"));

        _constraints.Add(
            new IsNotNullConstraint<string>(
                createUserViewModel.PasswordConfirmation, "passwordConfirmation", "password is null"));
        _constraints.Add(
            new IsNotEmptyConstraint(
                createUserViewModel.PasswordConfirmation, "passwordConfirmation", "password is empty"));

        _constraints.Add(
            new IsNotNullConstraint<int>(
                createUserViewModel.Role, "role", "role is null"));
    }
}