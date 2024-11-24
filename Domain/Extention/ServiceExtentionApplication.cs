using Domain.IServices;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extention;

public static class ServiceExtentionApplication
{
    public static IServiceCollection AddSharedApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClientService, ClientService>();

        return services;
    }
}
