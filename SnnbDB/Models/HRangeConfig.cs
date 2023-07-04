using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class HRangeConfig
{
    public int Id { get; set; }

    public string Unit { get; set; } = null!;

    public string Table { get; set; } = null!;

    public string Attribute { get; set; } = null!;

    public double Lower { get; set; }

    public double Upper { get; set; }

    public bool Enabled { get; set; }

    public bool InRange { get; set; }
}
