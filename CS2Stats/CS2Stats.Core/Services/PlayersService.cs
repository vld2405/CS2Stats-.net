using CS2Stats.Core.Dtos.Common.Players;
using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Dtos.Responses.Players;
using CS2Stats.Core.Exceptions;
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

    public async Task UpdatePlayerAsync(int id, UpdatePlayerRequest payload)
    {
        var existingPlayer = await playersRepository.GetFirstOrDefaultAsync(id);

        if (existingPlayer == null)
        {
            throw new NotFoundException($"Player with ID {id} not found.");
        }

        if (payload.Username != null)
            existingPlayer.Username = payload.Username;

        if (payload.RealName != null)
            existingPlayer.RealName = payload.RealName;

        if (payload.Country != null)
            existingPlayer.Country = payload.Country;

        if (payload.TeamId.HasValue)
            existingPlayer.TeamId = payload.TeamId.Value;

        if (payload.JoinDate.HasValue)
            existingPlayer.JoinDate = payload.JoinDate.Value;

        existingPlayer.ModifiedAt = DateTime.UtcNow;

        await playersRepository.UpdateAsync(existingPlayer);
    }
}