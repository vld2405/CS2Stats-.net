using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Core.Dtos.Common.Teams
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }
        public DateOnly FoundedDate { get; set; }
        public string? Country { get; set; }
    }
}
