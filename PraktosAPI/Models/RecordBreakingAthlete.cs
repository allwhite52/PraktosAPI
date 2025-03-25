using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class RecordBreakingAthlete
{
    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Result { get; set; }

    public decimal WorldRecord { get; set; }

    public string SportName { get; set; } = null!;
}
