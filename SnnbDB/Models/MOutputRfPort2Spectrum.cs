using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MOutputRfPort2Spectrum
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string Spectrum { get; set; } = null!;
}
