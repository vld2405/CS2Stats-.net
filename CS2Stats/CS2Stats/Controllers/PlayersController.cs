using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Services;
using Microsoft.AspNetCore.Mvc;

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
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var result = await playersService.GetPlayersAsync();

            var pagedResult = result.Players
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(); 

            return Ok(pagedResult);
        }
    }
}
