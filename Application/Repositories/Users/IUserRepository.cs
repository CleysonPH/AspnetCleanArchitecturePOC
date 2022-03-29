using ProjectManager.Core.Repositories;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Repositories.Users;

public interface IUserRepository : ICrudRepository<User, int>
{
    User? GetByEmail(string email);
}
