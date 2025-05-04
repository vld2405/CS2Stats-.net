using CS2Stats.Core.Dtos.Requests.Teams;
using CS2Stats.Database.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Core.Mapping
{
    public static class TeamsMappingExtensions
    {
        public static Team ToEntity(this AddTeamRequest payload)
        {
            var teamEntity = new Team()
            {
                Name = payload.Name,
                Country = payload.Country,
                FoundedDate = payload.FoundedDate
            };

            return teamEntity;
        }
    }
}
