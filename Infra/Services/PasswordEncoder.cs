using ProjectManager.Application.Services;

namespace ProjectManager.Infra.Services;

public class PasswordEncoder : IPasswordEncoder
{
    public string Encode(string rawPassword)
    {
        return rawPassword;
    }
}