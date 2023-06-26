using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.Rest;

#region IP4Config
public class IP4Config 
{
    public RestString addresses { get; set; }
    public RestString address { get; set; }
    public RestInt32 netmask { get; set; }
}

public class Nic : FactoryBase
{
    public IP4Config structure { get; set; }
}

#endregion
