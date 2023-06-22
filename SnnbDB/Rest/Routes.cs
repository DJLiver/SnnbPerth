using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnnbDB.Rest;


#region Routes
public class Routes : FactoryBase
{
    public List<NetworkRoutes> array { get; set; }
}
public class NetworkRoutes : FactoryBase
{
    public NetworkRoute networkRoute { get; set; }
}
public class NetworkRoute
{
    public string destination { get; set; }
    public string gateway { get; set; }
    public RestInt32 netmask { get; set; }

}

#endregion
