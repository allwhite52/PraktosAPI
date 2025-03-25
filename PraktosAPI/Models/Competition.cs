using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class Competition
{
    public int CompetitionId { get; set; }

    public string CompetitionName { get; set; } = null!;

    public DateOnly? CompetitionDate { get; set; }

    public string? SportLocation { get; set; }

    public int? SportId { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual Sport? Sport { get; set; }
}
