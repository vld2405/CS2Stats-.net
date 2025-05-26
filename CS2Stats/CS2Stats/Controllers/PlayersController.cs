using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CS2Stats.Api.Controllers
{
    [ApiController]
    [Route("players")]

    public class PlayersController(PlayersService playersService) : ControllerBase
    {
        [HttpPost("add-player")]
        public async Task<IActionResult> AddPlayer([FromBody] AddPlayerRequest payload)
        {
            await playersService.AddPlayerAsync(payload);
            return Ok("Player added successfully");
        }


        [HttpGet("get-players")]
        public async Task<IActionResult> GetPlayers(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int shownItems = 5,
            [FromQuery] string? team = null,
            [FromQuery] string? country = null)
        {
            var result = await playersService.GetPlayersAsync();

            var filteredPlayers = result.Players.AsQueryable();

            if (team != null)
            {
                filteredPlayers = filteredPlayers.Where(p => p.TeamName.Equals(team, StringComparison.OrdinalIgnoreCase));
            }
            
            if (country != null)
            {
                filteredPlayers = filteredPlayers.Where(p => p.Country.Equals(country, StringComparison.OrdinalIgnoreCase));
            }

            var pagedResult = filteredPlayers
                .Skip((pageIndex - 1) * shownItems)
                .Take(shownItems)
                .ToList();

            return Ok(pagedResult);
        }
    }
}
