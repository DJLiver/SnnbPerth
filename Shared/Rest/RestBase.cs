using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbFailover.Shared.Rest;


#region Base classes
public class FactoryBase
{
    public string factory { get; set; }
    public string factoryType { get; set; }
}

public class RestBool : FactoryBase
{
    public bool value { get; set; }
}
public class RestUInt32 : FactoryBase
{
    public uint value { get; set; }
}
public class RestUInt16 : FactoryBase
{
    public ushort value { get; set; }
}
public class RestUInt8 : FactoryBase
{
    public byte value { get; set; }
}
public class RestString : FactoryBase
{
    public string value { get; set; } = string.Empty;
}
public class RestInt32 : FactoryBase
{
    public int value { get; set; }
}
public class RestInt64 : FactoryBase
{
    public long value { get; set; }
}
public class RestUint16 : FactoryBase
{
    public ushort value { get; set; }
}
public class RestUInt64 : FactoryBase
{
    public ulong value { get; set; }
}
public class RestDouble : FactoryBase
{
    public double value { get; set; }
}
public class RestFloat : FactoryBase
{
    public float value { get; set; }
}
public class RestStringArray : FactoryBase
{
    public List<RestString> array { get; set; }
}

#endregion
