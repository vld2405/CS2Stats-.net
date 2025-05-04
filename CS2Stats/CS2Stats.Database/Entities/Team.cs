using System.ComponentModel.DataAnnotations;

namespace CS2Stats.Database.Entities;

public class Team : BaseEntity
{
    [MaxLength(50)]
    public string? Name { get; set; }
    public DateOnly FoundedDate { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
}
