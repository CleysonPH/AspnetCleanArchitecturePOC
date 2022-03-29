using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Infra.EntitiesConfig;

namespace ProjectManager.Infra.Contexts;

public class SqliteContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SqliteContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
    }
}