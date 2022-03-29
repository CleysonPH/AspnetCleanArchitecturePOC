using ProjectManager.Application.Repositories.Users;
using ProjectManager.Domain.Entities;
using ProjectManager.Infra.Contexts;

namespace ProjectManager.Infra.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly SqliteContext _context;

    public UserRepository(SqliteContext context)
    {
        _context = context;
    }

    public void Add(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(User entity)
    {
        _context.Users.Remove(entity);
        _context.SaveChanges();
    }

    public bool Exists(int id)
    {
        return _context.Users.Any(x => x.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User? GetByEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
        }

        return _context.Users.FirstOrDefault(x => x.Email == email);
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public void Update(User entity)
    {
        _context.Users.Update(entity);
        _context.SaveChanges();
    }
}