using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class DatabaseMaint
{
    public int Id { get; set; }

    public string DBtable { get; set; } = null!;

    public int DaysToKeep { get; set; }

    public bool Enabled { get; set; }
}
