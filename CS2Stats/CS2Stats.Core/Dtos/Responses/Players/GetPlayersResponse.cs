using CS2Stats.Core.Dtos.Common.Players;

namespace CS2Stats.Core.Dtos.Responses.Players
{
    public class GetPlayersResponse
    {
        public List<PlayerDto> Players { get; set; } = new List<PlayerDto>();
    }
}
