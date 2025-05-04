using CS2Stats.Core.Dtos.Requests.Teams;
using CS2Stats.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2Stats.Api.Controllers
{
    [ApiController]
    [Route("teams")]

    public class TeamsController(TeamsService teamsService, PlayersService playersService) : ControllerBase
    {
        [HttpPost("add-team")]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamRequest payload)
        {
            await teamsService.AddTeamAsync(payload);
            return Ok("Event added successfully");
        }

        [HttpGet("get-events")]
        public async Task<IActionResult> GetEvents()
        {
            var result = await teamsService.GetEventsAsync();
            return Ok(result);
        }
    }
}
