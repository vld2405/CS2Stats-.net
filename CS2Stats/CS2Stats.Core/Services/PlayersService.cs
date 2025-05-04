using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Mapping;
using CS2Stats.Database.Repositories;

namespace CS2Stats.Core.Services;

public class PlayersService
{
    private readonly PlayersRepository playersRepository;

    public PlayersService(PlayersRepository playersRepository)
    {
        this.playersRepository = playersRepository;
        Console.WriteLine("PlayersService initialized");
    }

    public async Task AddPlayerAsync(AddPlayerRequest payload)
    {
        var newPlayer = payload.ToEntity();
        newPlayer.CreatedAt = DateTime.UtcNow;

        await playersRepository.AddAsync(newPlayer);
    }

}
