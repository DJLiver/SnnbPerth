using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MetricMonitor
{
    public int Id { get; set; }

    public DateTime DateStamp { get; set; }

    public string Target { get; set; } = null!;

    public double MaxInputRfPort1AdcSaturation { get; set; }

    public double MaxInputRfPort1AdcSaturationPercent { get; set; }

    public double MaxInputRfPort1Power { get; set; }

    public double MaxOutputRfPort1AdcSaturation { get; set; }

    public double MaxOutputRfPort1AdcSaturationPercent { get; set; }

    public double MaxOutputRfPort1Power { get; set; }

    public double MinInputRfPort1AdcSaturation { get; set; }

    public double MinInputRfPort1AdcSaturationPercent { get; set; }

    public double MinInputRfPort1Power { get; set; }

    public double MinOutputRfPort1AdcSaturation { get; set; }

    public double MinOutputRfPort1AdcSaturationPercent { get; set; }

    public double MinOutputRfPort1Power { get; set; }
}
