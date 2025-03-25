using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class Sport
{
    public int SportId { get; set; }

    public string SportName { get; set; } = null!;

    public string UnitOfMeasurement { get; set; } = null!;

    public decimal WorldRecord { get; set; }

    public DateOnly WorldRecordDate { get; set; }

    public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();
}
