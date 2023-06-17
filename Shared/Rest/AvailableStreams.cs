using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbFailover.Shared.Rest;

#region AvailableStreams
public class StructureAvailableStreams
{
    public RestString sourceIpAddress { get; set; }
    public RestString sourcePort { get; set; }
    public RestUInt32 streamId { get; set; }
    public RestDouble centerFrequency { get; set; }
    public RestDouble bandwidth { get; set; }
    public RestDouble sampleRate { get; set; }
    public RestDouble gain { get; set; }
    public RestUInt8 sampleWidth { get; set; }
    public RestBool pfecEnabled { get; set; }
    public RestBool irigLocked { get; set; }
    public RestBool onePpsPresent { get; set; }
    public RestBool tenMhzLocked { get; set; }
}

public class ArrayAvailableStreams : FactoryBase
{
    public StructureAvailableStreams structure { get; set; }
}

public class AvailableStreams : FactoryBase
{
    public List<ArrayAvailableStreams> array { get; set; }
}

#endregion
