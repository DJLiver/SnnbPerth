using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MControlNic
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string Addresses { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Netmask { get; set; }
}
