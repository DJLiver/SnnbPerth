using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MRfOutputStream
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string Name { get; set; } = null!;

    public double CurrentBuffer { get; set; }

    public decimal DataSampleWidth { get; set; }

    public string DataSource { get; set; } = null!;

    public decimal DesiredBuffer { get; set; }

    public decimal DesiredDelay { get; set; }

    public decimal DestinationPort { get; set; }

    public decimal DroppedPackets { get; set; }

    public long FrequencyOffset { get; set; }

    public decimal GapCount { get; set; }

    public decimal MeasuredDelay { get; set; }

    public decimal MeasuredNetworkRate { get; set; }

    public decimal MeasuredPacketRate { get; set; }

    public double NetStreamGain { get; set; }

    public double NetworkDelay { get; set; }

    public double PacketOverhead { get; set; }

    public string PfecDecoderStatus { get; set; } = null!;

    public decimal PfecMissingSets { get; set; }

    public decimal PfecRepairedPackets { get; set; }

    public decimal PfecTotalPackets { get; set; }

    public decimal PfecUnrepairablePackets { get; set; }

    public bool PreserveLatency { get; set; }

    public decimal PreserveLatencyLatePackets { get; set; }

    public decimal PreserveLatencyMaxBurstLoss { get; set; }

    public decimal PreserveLatencyMissingPackets { get; set; }

    public decimal PreserveLatencyOutOfOrderPackets { get; set; }

    public decimal PreserveLatencyReleaseMargin { get; set; }

    public string ReleaseMode { get; set; } = null!;

    public string SourceHost { get; set; } = null!;

    public decimal SourcePort { get; set; }

    public double StreamBandwidth { get; set; }

    public bool StreamEnable { get; set; }

    public decimal StreamId { get; set; }

    public double StreamSampleRate { get; set; }

    public decimal UnderflowCount { get; set; }

    public bool UpstreamIrigLocked { get; set; }

    public bool UpstreamOnePpsLocked { get; set; }

    public double UpstreamPathGain { get; set; }

    public bool UpstreamTenMhzLocked { get; set; }

    public bool UseLocalReference { get; set; }
}
