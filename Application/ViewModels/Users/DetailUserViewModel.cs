namespace ProjectManager.Application.ViewModels.Users;

public class DetailUserViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }

    public DetailUserViewModel(int id, string name, string email, int role)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
    }
}
