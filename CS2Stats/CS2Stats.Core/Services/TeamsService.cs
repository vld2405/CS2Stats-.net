using CS2Stats.Core.Dtos.Common.Players;
using CS2Stats.Core.Dtos.Common.Teams;
using CS2Stats.Core.Dtos.Requests.Players;
using CS2Stats.Core.Dtos.Requests.Teams;
using CS2Stats.Core.Dtos.Responses.Players;
using CS2Stats.Core.Dtos.Responses.Teams;
using CS2Stats.Core.Mapping;
using CS2Stats.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Core.Services
{
    public class TeamsService
    {
        private readonly TeamsRepository teamsRepository;

        public TeamsService(TeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
            Console.WriteLine("TicketsService initialized");
        }

        public async Task AddTeamAsync(AddTeamRequest payload)
        {
            var newTeam = payload.ToEntity();
            newTeam.CreatedAt = DateTime.UtcNow;

            await teamsRepository.AddAsync(newTeam);
        }

        public async Task<GetTeamsResponse> GetEventsAsync()
        {
            var teams = await teamsRepository.GetAllAsync();

            var result = new GetTeamsResponse
            {
                Teams = teams.Select(e => new TeamDto
                {
                    Id = e.Id,
                    TeamName = e.Name,
                    Country = e.Country,
                    FoundedDate = e.FoundedDate
                }).ToList()
            };

            return result;
        }
    }
}
