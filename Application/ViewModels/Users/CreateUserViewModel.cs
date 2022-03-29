namespace ProjectManager.Application.ViewModels.Users;

public class CreateUserViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
    public int Role { get; set; }

    public CreateUserViewModel(
        string name,
        string email,
        string password,
        string passwordConfirmation,
        int role)
    {
        Name = name;
        Email = email;
        Password = password;
        PasswordConfirmation = passwordConfirmation;
        Role = role;
    }
}