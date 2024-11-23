using Entities.Model;
using Entities.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Extention;

public static class ServiceExtentionEntities
{
    public static IServiceCollection AddSharedEntities(this IServiceCollection services)
    {
        services.AddScoped<IValidator<User>, UserValidator>();
        services.AddScoped<IValidator<Client>, ClientValidator>();

        return services;
    }
}
