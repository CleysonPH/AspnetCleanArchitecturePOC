using ProjectManager.Application.Repositories.Users;
using ProjectManager.Domain.Entities;
using ProjectManager.Infra.Contexts;
using ProjectManager.Infra.Entities;

namespace ProjectManager.Infra.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly SqliteContext _context;

    public UserRepository(SqliteContext context)
    {
        _context = context;
    }

    public User Add(User user)
    {
        var userEntity = UserEntity.Of(user);
        _context.Users.Add(userEntity);
        _context.SaveChanges();
        return userEntity.ToDomain();
    }

    public void Delete(User entity)
    {
        _context.Users.Remove(UserEntity.Of(entity));
        _context.SaveChanges();
    }

    public bool Exists(int id)
    {
        return _context.Users.Any(x => x.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.Select(x => x.ToDomain()).AsEnumerable();
    }

    public User? GetByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
        }

        return _context.Users.FirstOrDefault(x => x.Email == email)?.ToDomain();
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id)?.ToDomain();
    }

    public User Update(User entity)
    {
        var userEntity = UserEntity.Of(entity);
        _context.Users.Update(userEntity);
        _context.SaveChanges();
        return userEntity.ToDomain();
    }
}