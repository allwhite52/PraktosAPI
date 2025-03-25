using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class CompetitionPlace
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Place { get; set; }

    public string CompetitionName { get; set; } = null!;

    public string? SportLocation { get; set; }

    public DateOnly? CompetitionDate { get; set; }

    public string SportName { get; set; } = null!;
}
