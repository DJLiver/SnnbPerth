using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.newModels;

public partial class MDataNic
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Addresses { get; set; }

    public string? Address { get; set; }

    public int? Netmask { get; set; }
}
