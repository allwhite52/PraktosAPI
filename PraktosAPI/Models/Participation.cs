using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class Participation
{
    public int ParticipationsId { get; set; }

    public int SportId { get; set; }

    public int AthleteId { get; set; }

    public int CompetitionId { get; set; }

    public decimal Result { get; set; }

    public int Place { get; set; }

    public virtual Athlete Athlete { get; set; } = null!;

    public virtual Competition Competition { get; set; } = null!;

    public virtual Sport Sport { get; set; } = null!;
}
