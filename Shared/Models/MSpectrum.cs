using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MSpectrum
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? SpectrumType { get; set; }

    public string? InputRfPort1Spectrum { get; set; }
}
