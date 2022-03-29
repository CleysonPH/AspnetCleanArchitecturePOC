using ProjectManager.Core.Exceptions;

namespace ProjectManager.Api.V1.Common;

public class ErrorResponse
{
    public int Status { get; set; }
    public string Error { get; set; }
    public string Cause { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public ICollection<FieldError>? Errors { get; set; }

    public ErrorResponse(
        int status,
        string error,
        Exception exception)
    {
        Status = status;
        Error = error;
        Cause = exception.GetType().Name;
        Message = exception.Message;
        Timestamp = DateTime.UtcNow;
    }

    public ErrorResponse(ValidationException exception)
    {
        Status = 400;
        Error = "Bad Request";
        Cause = exception.GetType().Name;
        Message = exception.Message;
        Timestamp = DateTime.UtcNow;
        Errors = exception.Errors;
    }
}