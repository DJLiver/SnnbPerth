using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.Rest;

#region RfInputStreams
public class StructureRfInputStream
{
    public RestString name { get; set; }
    public RestUInt32 bitRate { get; set; }
    public RestUInt8 dataSampleWidth { get; set; }
    public RestString destinationHost { get; set; }
    public RestUInt16 destinationPort { get; set; }
    public RestInt64 frequencyOffset { get; set; }
    public RestUInt32 maximumPacketSize { get; set; }
    public RestUInt64 measuredNetworkRate { get; set; }
    public RestUInt32 measuredPacketRate { get; set; }
    public RestDouble minimumProcessingDelay { get; set; }
    public RestDouble packetOverhead { get; set; }
    public RestBool pfecEnable { get; set; }
    public RestString routeSearch { get; set; }
    public RestUInt16 sourcePort { get; set; }
    public RestUInt64 streamBandwidth { get; set; }
    public RestBool streamEnable { get; set; }
    public RestDouble streamGain { get; set; }
    public RestUInt32 streamId { get; set; }
    public RestDouble streamSampleRate { get; set; }
}

public class ArrayRfInputStream : FactoryBase
{
    public StructureRfInputStream structure { get; set; }
}

public class RfInputStream : FactoryBase
{
    public List<ArrayRfInputStream> array { get; set; }
}

#endregion
