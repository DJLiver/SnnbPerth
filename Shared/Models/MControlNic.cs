using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MControlNic
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Addresses { get; set; }

    public string? Address { get; set; }

    public int? Netmask { get; set; }
}
