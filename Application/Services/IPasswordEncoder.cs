namespace ProjectManager.Application.Services;

public interface IPasswordEncoder
{
    string Encode(string rawPassword);
}
