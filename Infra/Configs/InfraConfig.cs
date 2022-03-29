using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.Services;
using ProjectManager.Application.UseCases.Users;
using ProjectManager.Application.Validators.Users;
using ProjectManager.Infra.Contexts;
using ProjectManager.Infra.Mappers.Users;
using ProjectManager.Infra.Repositories.Users;
using ProjectManager.Infra.Services;
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
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void ConfigureMappers(this IServiceCollection services)
    {
        services.AddScoped<IUserMapper, UserMapper>();
    }

    private static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserValidator, CreateUserValidator>();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncoder, PasswordEncoder>();
    }
}