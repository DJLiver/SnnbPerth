using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MDataNic
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Addresses { get; set; }

    public string? Address { get; set; }

    public int? Netmask { get; set; }
}
