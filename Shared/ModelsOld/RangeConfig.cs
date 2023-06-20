using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class RangeConfig
{
    public int Id { get; set; }

    public string Unit { get; set; } = null!;

    public string Attr { get; set; } = null!;

    public double Lower { get; set; }

    public double Upper { get; set; }

    public bool Enabled { get; set; }

    public bool InRange { get; set; }
}
