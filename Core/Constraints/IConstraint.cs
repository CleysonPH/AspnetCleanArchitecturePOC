using ProjectManager.Core.Exceptions;

namespace ProjectManager.Core.Constraints;

public interface IConstraint
{
    void Execute(ValidationException validationException);
}