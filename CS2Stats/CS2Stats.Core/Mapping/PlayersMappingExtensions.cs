using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace CS2Stats.Core.Mapping
{
    public static class PlayersMappingExtensions
    {
        public static Player ToEntity(this AddPlayerRequest payload)
        {
            var playerEntity = new Player
            {
                Username = payload.Username,
                RealName = payload.RealName,
                Team = payload.Team,
                Country = payload.Country,
                JoinDate = payload.JoinDate
            };

            return playerEntity;
        }
    }
}
