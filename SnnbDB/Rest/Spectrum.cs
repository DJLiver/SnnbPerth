using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.Rest;

#region Spectrum
public class SpectrumData : FactoryBase
{
    public string data { get; set; } 
    public int bitLength { get; set; }
}

public class Spectrum : FactoryBase
{
    public SpectrumData data { get; set; }
}

#endregion
