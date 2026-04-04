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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHasher, BCryptHasher>();

        services.AddScoped<IActivityRepository, ActivityRepository>();

        services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();

        return services;
    }
}
