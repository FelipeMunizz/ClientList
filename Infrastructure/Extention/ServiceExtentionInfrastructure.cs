using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extention;

public static class ServiceExtentionInfrastructure
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
