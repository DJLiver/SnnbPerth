using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MRoute
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string Destination { get; set; } = null!;

    public string Gateway { get; set; } = null!;

    public int Netmask { get; set; }
}
