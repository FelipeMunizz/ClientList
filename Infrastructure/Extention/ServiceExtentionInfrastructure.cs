using Domain.Interfaces;
using Helpers.Utility;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Infrastructure.Extention;

public static class ServiceExtentionInfrastructure
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClientRepository, ClienteRepository>();

        services.AddScoped<IDbConnection>(sp =>
        {
            var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString(Util.ConectionString);
            return new SqlConnection(connectionString);
        });
        services.AddScoped<AppDbContext>();

        return services;
    }
}
