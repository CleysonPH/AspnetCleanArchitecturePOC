using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infra.Mappers.Users;

public class UserMapper : IUserMapper
{
    public DetailUserViewModel ToDetailViewModel(User user)
    {
        return new DetailUserViewModel(
            user.Id,
            user.Name,
            user.Email,
            (int)user.Role);
    }

    public User ToEntity(CreateUserViewModel createUserViewModel)
    {
        return new User(
            createUserViewModel.Name,
            createUserViewModel.Email,
            createUserViewModel.Password,
            IntToRole(createUserViewModel.Role));
    }

    private Role IntToRole(int role)
    {
        return role switch
        {
            1 => Role.Admin,
            2 => Role.Manager,
            3 => Role.Admin,
            _ => throw new InvalidOperationException()
        };
    }
}
