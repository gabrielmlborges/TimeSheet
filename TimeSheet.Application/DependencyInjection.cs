using Microsoft.Extensions.DependencyInjection;
using TimeSheet.Application.Interfaces;
using TimeSheet.Application.Services;

namespace TimeSheet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IActivityService, ActivityService>();

        return services;
    }
}
