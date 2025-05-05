using CS2Stats.Core.Dtos.Requests.Teams;
using CS2Stats.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2Stats.Api.Controllers
{
    [ApiController]
    [Route("teams")]

    public class TeamsController(TeamsService teamsService) : ControllerBase
    {
        [HttpPost("add-team")]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamRequest payload)
        {
            await teamsService.AddTeamAsync(payload);
            return Ok("Team added successfully");
        }

        [HttpGet("get-teams")]
        public async Task<IActionResult> GetEvents()
        {
            var result = await teamsService.GetEventsAsync();
            return Ok(result);
        }
    }
}
