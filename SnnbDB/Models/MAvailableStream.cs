using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MAvailableStream
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string SourceIpAddress { get; set; } = null!;

    public string SourcePort { get; set; } = null!;

    public decimal StreamId { get; set; }

    public double CenterFrequency { get; set; }

    public double Bandwidth { get; set; }

    public double SampleRate { get; set; }

    public double Gain { get; set; }

    public decimal SampleWidth { get; set; }

    public bool PfecEnabled { get; set; }

    public bool IrigLocked { get; set; }

    public bool OnePpsPresent { get; set; }

    public bool TenMhzLocked { get; set; }
}
