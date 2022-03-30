using ProjectManager.Application.Mappers;
using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.Repositories.Projects;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.Services;
using ProjectManager.Application.UseCases.Projects;
using ProjectManager.Application.UseCases.Users;
using ProjectManager.Application.Validators.Projects;
using ProjectManager.Application.Validators.Users;
using ProjectManager.Infra.Contexts;
using ProjectManager.Infra.Mappers.Projects;
using ProjectManager.Infra.Mappers.Users;
using ProjectManager.Infra.Repositories.Projects;
using ProjectManager.Infra.Repositories.Users;
using ProjectManager.Infra.Services;
using ProjectManager.Infra.Validators.Projects;
using ProjectManager.Infra.Validators.Users;

namespace ProjectManager.Infra.Configs;

public static class InfraConfig
{
    public static void ConfigureInfra(this IServiceCollection services)
    {
        ConfigureMappers(services);
        ConfigureServices(services);
        ConfigureUseCases(services);
        ConfigureDbContext(services);
        ConfigureValidators(services);
        ConfigureRepositories(services);
    }

    private static void ConfigureDbContext(this IServiceCollection services)
    {
        services.AddDbContext<SqliteContext>();
    }

    private static void ConfigureUseCases(this IServiceCollection services)
    {
        services.AddTransient<FindAllUsersUseCase>();
        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<FindUserByIdUseCase>();
        services.AddTransient<DeleteUserByIdUseCase>();

        services.AddTransient<CreateProjectUseCase>();
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
    }

    private static void ConfigureMappers(this IServiceCollection services)
    {
        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<IProjectMapper, ProjectMapper>();
    }

    private static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserValidator, CreateUserValidator>();
        services.AddScoped<ICreateProjectValidator, CreateProjectValidator>();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncoder, PasswordEncoder>();
    }
}