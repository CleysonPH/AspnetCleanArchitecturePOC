using ProjectManager.Application.Validators.Projects;
using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Core.Constraints;
using ProjectManager.Core.Exceptions;
using ProjectManager.Infra.Constraints;

namespace ProjectManager.Infra.Validators.Projects;

public class CreateProjectValidator : ICreateProjectValidator
{
    private ICollection<IConstraint> _constraints;
    private ValidationException _validationException;

    public CreateProjectValidator()
    {
        _constraints = new List<IConstraint>();
        _validationException = new ValidationException();
    }

    public void Validate(CreateProjectViewModel input)
    {
        AddConstraints(input);

        _constraints.ToList().ForEach(c => c.Execute(_validationException));
        if (_validationException.HasErrors())
        {
            throw _validationException;
        }
    }

    private void AddConstraints(CreateProjectViewModel input)
    {
        _constraints.Add(
            new IsNotNullConstraint<string>(
                input.Name, "name", "name is null"));
        _constraints.Add(
            new IsNotEmptyConstraint(
                input.Name, "name", "name is empty"));

        _constraints.Add(
            new IsNotNullConstraint<int>(
                input.LeaderId, "leaderId", "leaderId is null"));

        _constraints.Add(
            new IsNotNullConstraint<int>(
                input.ResponsableId, "responsableId", "responsableId is empty"));
    }
}