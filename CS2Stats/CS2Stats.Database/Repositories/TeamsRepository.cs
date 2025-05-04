using CS2Stats.Database.Context;
using CS2Stats.Database.Entities;

namespace CS2Stats.Database.Repositories;

public class TeamsRepository : BaseRepository<Team>
{
    public TeamsRepository(CS2StatsDatabaseContext cs2StatsDatabaseContext) : base(cs2StatsDatabaseContext)
    {
        this.cs2StatsDatabaseContext = cs2StatsDatabaseContext;
        Console.WriteLine("TeamsRepository initialized");
    }

    public async Task AddAsync(Player entity)
    {
        cs2StatsDatabaseContext.Players.Add(entity);
        await SaveChangesAsync();
    }
}
