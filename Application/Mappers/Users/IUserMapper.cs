using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Mappers.Users;

public interface IUserMapper
{
    User ToEntity(CreateUserViewModel createUserViewModel);
    DetailUserViewModel ToDetailViewModel(User user);
}
