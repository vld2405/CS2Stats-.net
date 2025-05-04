using CS2Stats.Core.Dtos.Common.Players;

namespace CS2Stats.Core.Dtos.Responses.Players
{
    internal class GetPlayersRespone
    {
        public List<PlayerDto> Events { get; set; } = new List<PlayerDto>();
    }
}
