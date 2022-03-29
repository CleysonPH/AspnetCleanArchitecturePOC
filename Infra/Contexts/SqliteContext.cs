using Microsoft.EntityFrameworkCore;
using ProjectManager.Infra.Entities;
using ProjectManager.Infra.EntitiesConfig;

namespace ProjectManager.Infra.Contexts;

public class SqliteContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SqliteContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<UserEntity>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<ProjectEntity>(new ProjectConfiguration());
    }
}