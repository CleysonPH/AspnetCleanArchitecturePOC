namespace ProjectManager.Core.Exceptions;

public class ValidationException : Exception
{
    public ICollection<FieldError> Errors { get; set; }

    public ValidationException() : base("Validation failed")
    {
        Errors = new List<FieldError>();
    }

    public void AddError(string field, string message)
    {
        Errors.Add(new FieldError(field, message));
    }

    public bool HasErrors()
    {
        return Errors.Any();
    }
}

public class FieldError
{
    public string Field { get; set; }
    public string Message { get; set; }

    public FieldError(string field, string message)
    {
        Field = field;
        Message = message;
    }
}