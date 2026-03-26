using Microsoft.Extensions.DependencyInjection;
using TimeSheet.Application.Interfaces;
using TimeSheet.Infrastructure.Repositories;
using TimeSheet.Infrastructure.Authentication;
using TimeSheet.Infrastructure.Cryptography;

namespace TimeSheet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Registra Repositórios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();

        // Registra Serviços de Infra (Token e Hash)
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHasher, BCryptHasher>();

        return services;
    }
}
