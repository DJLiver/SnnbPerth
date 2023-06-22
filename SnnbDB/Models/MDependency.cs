using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MDependency
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Dependant { get; set; }
}
