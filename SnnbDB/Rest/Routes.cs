using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.Rest;


#region Routes
public class Routes : FactoryBase
{
    public ArrayNR[] array { get; set; }
}
public class ArrayNR : FactoryBase
{
    public NetworkRoute structure { get; set; }
}
public class NetworkRoute
{
    public RestString destination { get; set; }
    public RestString gateway { get; set; }
    public RestInt32 netmask { get; set; }

}

#endregion
