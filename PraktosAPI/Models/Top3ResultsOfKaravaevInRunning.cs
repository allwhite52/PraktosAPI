using System;
using System.Collections.Generic;

namespace PraktosAPI.Models;

public partial class Top3ResultsOfKaravaevInRunning
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal BestResult { get; set; }

    public string SportName { get; set; } = null!;
}
