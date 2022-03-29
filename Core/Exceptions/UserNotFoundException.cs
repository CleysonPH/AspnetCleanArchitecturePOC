namespace ProjectManager.Core.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException() : base("User not found")
    { }
}
