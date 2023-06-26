using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MMulticastGroupSubscription
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string McastAddr { get; set; } = null!;
}
