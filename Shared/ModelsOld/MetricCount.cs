using System;
using System.Collections.Generic;

namespace SnnbFailover.Shared.Models;

public partial class MetricCount
{
    public int Id { get; set; }

    public DateTime DateStamp { get; set; }

    public string Target { get; set; } = null!;

    public double ComDiscardedPackets { get; set; }

    public double RfOutDroppedPackets { get; set; }

    public double RfOutGapCount { get; set; }

    public double RfOutPfecMissingSets { get; set; }

    public double RfOutPfecRepairedPackets { get; set; }

    public double RfOutPfecTotalPackets { get; set; }

    public double RfOutPfecUnrepairablePackets { get; set; }

    public double RfOutPreserveLatencyLatePackets { get; set; }

    public double RfOutPreserveLatencyMaxBurstLoss { get; set; }

    public double RfOutPreserveLatencyMissingPackets { get; set; }

    public double RfOutPreserveLatencyOutOfOrderPackets { get; set; }

    public double RfOutUnderflowCount { get; set; }
}
