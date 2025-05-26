using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Core.Dtos.Requests.Players
{
    public class UpdatePlayerRequest
    {
        public string? Username { get; set; }
        public string? RealName { get; set; }
        public string? Country { get; set; }
        public int? TeamId { get; set; }
        public DateOnly? JoinDate { get; set; }
    }
}
