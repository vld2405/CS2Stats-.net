using CS2Stats.Core.Dtos.Common.Players;
using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Dtos.Responses.Players;
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

    public async Task<GetPlayersResponse> GetPlayersAsync()
    {
        var players = await playersRepository.GetAllWithTeamsAsync();

        var result = new GetPlayersResponse
        {
            Players = players.Select(e => new PlayerDto
            {
                Id = e.Id,
                Username = e.Username,
                RealName = e.RealName,
                Country = e.Country,
                TeamId = e.TeamId,
                TeamName = e.Team?.Name,
                JoinDate = e.JoinDate
            }).ToList()
        };

        return result;
    }

}