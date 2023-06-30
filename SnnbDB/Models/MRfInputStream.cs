using SnnbDB.Rest;

using System;
using System.Collections.Generic;

namespace SnnbDB.Models;

public partial class MRfInputStream
{
    public int Id { get; set; }

    public int UnitId { get; set; }

    public string? Name { get; set; }

    public decimal? BitRate { get; set; }

    public decimal? DataSampleWidth { get; set; }

    public string? DestinationHost { get; set; }

    public decimal? DestinationPort { get; set; }

    public long? FrequencyOffset { get; set; }

    public decimal? MaximumPacketSize { get; set; }

    public decimal? MeasuredNetworkRate { get; set; }

    public decimal? MeasuredPacketRate { get; set; }

    public double? MinimumProcessingDelay { get; set; }

    public double? PacketOverhead { get; set; }

    public bool? PfecEnable { get; set; }

    public string? RouteSearch { get; set; }

    public decimal? SourcePort { get; set; }

    public decimal? StreamBandwidth { get; set; }

    public bool? StreamEnable { get; set; }

    public double? StreamGain { get; set; }

    public decimal? StreamId { get; set; }

    public double? StreamSampleRate { get; set; }

}
