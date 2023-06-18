using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.newModels;

public partial class MRoute
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Destination { get; set; }

    public string? Gateway { get; set; }

    public int? Netmask { get; set; }
}
