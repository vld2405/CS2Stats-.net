using CS2Stats.Database.Context;
using CS2Stats.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS2Stats.Database.Repositories;

public class PlayersRepository : BaseRepository<Player>
{
    public PlayersRepository(CS2StatsDatabaseContext cs2StatsDatabaseContext) : base(cs2StatsDatabaseContext)
    {
        this.cs2StatsDatabaseContext = cs2StatsDatabaseContext;
        Console.WriteLine("PlayersRepository initialized");
    }

    public async Task AddAsync(Player entity)
    {
        cs2StatsDatabaseContext.Players.Add(entity);
        await SaveChangesAsync();
    }

    public async Task<List<Player>> GetAllWithTeamsAsync()
    {
        return await cs2StatsDatabaseContext.Players
            .Include(p => p.Team)
            .Where(p => p.DeletedAt == null)
            .ToListAsync();
    }

    public async Task UpdateAsync(Player entity)
    {
        cs2StatsDatabaseContext.Players.Update(entity);
        await SaveChangesAsync();
    }
}
