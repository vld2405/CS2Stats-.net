using CS2Stats.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CS2Stats.Core;

public static class DIConfig
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<PlayersService>();
        services.AddScoped<TeamsService>();

        return services;
    }
}
