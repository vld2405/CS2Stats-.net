using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Globalization;

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
            [FromQuery] string? country = null,
            [FromQuery] string sortBy = "username")
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

            filteredPlayers = sortBy.ToLower() switch
            {
                "username" => filteredPlayers.OrderBy(p => p.Username),
                "realname" => filteredPlayers.OrderBy(p => p.RealName),
                "country" => filteredPlayers.OrderBy(p => p.Country),
                "team" => filteredPlayers.OrderBy(p => p.TeamName),
                "joindate" => filteredPlayers.OrderBy(p => p.JoinDate),
                "id" => filteredPlayers.OrderBy(p => p.Id),
                _ => filteredPlayers.OrderByDescending(p => p.Username)
            };

            var pagedResult = filteredPlayers
                .Skip((pageIndex - 1) * shownItems)
                .Take(shownItems)
                .ToList();

            Response.Headers.Add("Page-Index", pageIndex.ToString());
            Response.Headers.Add("Items-Shown", pagedResult.Count.ToString());
            
            if (team != null)
            {
                Response.Headers.Add("Team-filter", team.ToString());
            }
            if (country != null)
            {
                Response.Headers.Add("Country-filter", country.ToString());
            }

            Response.Headers.Add("Sorted-By", sortBy.ToString());

            return Ok(pagedResult);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerRequest payload)
        {
            await playersService.UpdatePlayerAsync(id, payload);
            return Ok("Player updated successfully");
        }
    }
}
