using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class Athlete
{
    public int AthleteId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int BirthYear { get; set; }

    public string Team { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();
}
