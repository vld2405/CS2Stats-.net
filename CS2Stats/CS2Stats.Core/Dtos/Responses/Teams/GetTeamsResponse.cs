using CS2Stats.Core.Dtos.Common.Teams;

namespace CS2Stats.Core.Dtos.Responses.Teams
{
    public class GetTeamsResponse
    {
        public List<TeamDto> Teams { get; set; } = new List<TeamDto>();
    }
}
