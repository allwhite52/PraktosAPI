using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class AthletesInMultipleSport
{
    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? SportsCount { get; set; }
}
