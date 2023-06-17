using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbFailover.Shared.Rest;


#region RfOutputStreams
public class StructureRfOutputStream
{
    public RestString name { get; set; }
    public RestDouble currentBuffer { get; set; }
    public RestUInt8 dataSampleWidth { get; set; }
    public RestString dataSource { get; set; }
    public RestUInt32 desiredBuffer { get; set; }
    public RestUInt32 desiredDelay { get; set; }
    public RestUInt16 destinationPort { get; set; }
    public RestUInt32 droppedPackets { get; set; }
    public RestInt64 frequencyOffset { get; set; }
    public RestUInt32 gapCount { get; set; }
    public RestUInt32 measuredDelay { get; set; }
    public RestUInt64 measuredNetworkRate { get; set; }
    public RestUInt32 measuredPacketRate { get; set; }
    public RestDouble netStreamGain { get; set; }
    public RestDouble networkDelay { get; set; }
    public RestDouble packetOverhead { get; set; }
    public RestString pfecDecoderStatus { get; set; }
    public RestUInt32 pfecMissingSets { get; set; }
    public RestUInt32 pfecRepairedPackets { get; set; }
    public RestUInt64 pfecTotalPackets { get; set; }
    public RestUInt32 pfecUnrepairablePackets { get; set; }
    public RestBool preserveLatency { get; set; }
    public RestUInt32 preserveLatencyLatePackets { get; set; }
    public RestUInt32 preserveLatencyMaxBurstLoss { get; set; }
    public RestUInt32 preserveLatencyMissingPackets { get; set; }
    public RestUInt32 preserveLatencyOutOfOrderPackets { get; set; }
    public RestUInt32 preserveLatencyReleaseMargin { get; set; } //nSec
    public RestString releaseMode { get; set; }
    public RestString sourceHost { get; set; }
    public RestUInt16 sourcePort { get; set; }
    public RestDouble streamBandwidth { get; set; }
    public RestBool streamEnable { get; set; }
    public RestUInt32 streamId { get; set; }
    public RestDouble streamSampleRate { get; set; }
    public RestUInt32 underflowCount { get; set; }
    public RestBool upstreamIrigLocked { get; set; }
    public RestBool upstreamOnePpsLocked { get; set; }
    public RestDouble upstreamPathGain { get; set; }
    public RestBool upstreamTenMhzLocked { get; set; }
    public RestBool useLocalReference { get; set; }
}

public class ArrayRfOutputStream : FactoryBase
{
    public StructureRfOutputStream structure { get; set; }
}

public class RfOutputStream : FactoryBase
{
    public List<ArrayRfOutputStream> array { get; set; }
}


#endregion
