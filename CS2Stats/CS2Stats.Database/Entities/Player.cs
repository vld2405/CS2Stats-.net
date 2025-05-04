using System.ComponentModel.DataAnnotations;

namespace CS2Stats.Database.Entities;

public class Player : BaseEntity
{
    [MaxLength(50)]
    public string? Username { get; set; }
    [MaxLength(50)]
    public string? RealName { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
    public Team? Team { get; set; }
    public DateOnly JoinDate { get; set; }
}
