using ProjectManager.Core.Constraints;
using ProjectManager.Core.Exceptions;

namespace ProjectManager.Infra.Constraints;

public class IsEmailConstraint : IConstraint
{
    private readonly string _value;
    private readonly string _field;
    private readonly string _message;

    public IsEmailConstraint(string value, string field, string message)
    {
        _value = value;
        _field = field;
        _message = message;
    }

    public void Execute(ValidationException validationException)
    {
        if (!_value.Contains("@"))
        {
            validationException.AddError(_field, _message);
        }
    }
}