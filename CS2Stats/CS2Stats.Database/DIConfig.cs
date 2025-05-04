using CS2Stats.Database.Context;
using CS2Stats.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CS2Stats.Database;

public static class DIConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<CS2StatsDatabaseContext>();
        services.AddScoped<DbContext, CS2StatsDatabaseContext>();
        services.AddScoped<PlayersRepository>();
        services.AddScoped<TeamsRepository>();

        return services;
    }
}
