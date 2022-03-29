using ProjectManager.Core.Constraints;
using ProjectManager.Core.Exceptions;

namespace ProjectManager.Infra.Constraints;

public class IsNotEmptyConstraint : IConstraint
{
    private readonly string _value;
    private readonly string _field;
    private readonly string _message;

    public IsNotEmptyConstraint(string value, string field, string message)
    {
        _value = value;
        _field = field;
        _message = message;
    }

    public void Execute(ValidationException validationException)
    {
        if (string.IsNullOrEmpty(_value))
        {
            validationException.AddError(_field, _message);
        }
    }
}