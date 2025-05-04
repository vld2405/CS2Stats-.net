using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Core.Dtos.Requests.Teams
{
    public class AddTeamRequest
    {
        public string? Name { get; set; }
        public DateOnly FoundedDate { get; set; }
        public string? Country { get; set; }
    }
}
