//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SnnbDB;
//internal class Class1
//{
//}


//public class Rootobject
//{
//    public Routes routes { get; set; }
//}

//public class Routes
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Array[] array { get; set; }
//}

//public class Array
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public Structure structure { get; set; }
//}

//public class Structure
//{
//    public Destination destination { get; set; }
//    public Gateway gateway { get; set; }
//    public Netmask netmask { get; set; }
//}

//public class Destination
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Gateway
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public string value { get; set; }
//}

//public class Netmask
//{
//    public string factory { get; set; }
//    public string factoryType { get; set; }
//    public int value { get; set; }
//}


//{
//    "routes": {
//      "factory": "Attribute",
//      "factoryType": "networkRoute[]",
//      "array": [
//        {
//          "factory": "Attribute",
//          "factoryType": "networkRoute",
//          "structure": {
//            "destination": {
//              "factory": "Attribute",
//              "factoryType": "string",
//              "value": "192.168.201.0"
//            },
//            "gateway": {
//    "factory": "Attribute",
//              "factoryType": "string",
//              "value": "192.168.200.1"
//            },
//            "netmask": {
//    "factory": "Attribute",
//              "factoryType": "int32",
//              "value": 24
//            }
//          }
//        }
//      ]
//    },
//}
