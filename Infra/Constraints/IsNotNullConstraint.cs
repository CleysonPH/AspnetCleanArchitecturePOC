using ProjectManager.Core.Constraints;
using ProjectManager.Core.Exceptions;

namespace ProjectManager.Infra.Constraints;

public class IsNotNullConstraint<Value> : IConstraint
{
    private readonly Value _value;
    private readonly string _field;
    private readonly string _message;

    public IsNotNullConstraint(Value value, string field, string message)
    {
        _value = value;
        _field = field;
        _message = message;
    }

    public void Execute(ValidationException validationException)
    {
        if (_value == null)
        {
            validationException.AddError(_field, _message);
        }
    }
}