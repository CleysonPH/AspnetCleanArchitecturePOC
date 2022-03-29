using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public User(string name, string email, string password, Role role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        ValidadeData();
    }

    public User(int id, string name, string email, string password, Role role)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        ValidadeData();
    }

    private void ValidadeData()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrEmpty(Email))
            throw new ArgumentException("Email is required");

        if (string.IsNullOrEmpty(Password))
            throw new ArgumentException("Password is required");

        if (!Email.Contains("@"))
            throw new ArgumentException("Email is invalid");
    }
}