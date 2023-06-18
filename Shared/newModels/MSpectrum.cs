using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.newModels;

public partial class MSpectrum
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? SpectrumType { get; set; }

    public string? InputRfPort1Spectrum { get; set; }
}
