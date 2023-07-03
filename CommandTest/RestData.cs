using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace CommandTest;
public static class RestData
{
    public static void SetRestData(string IP, string command, string json)
    {
        var client = new RestClient(IP);

        //var request = new CreateOrder()
        var request = new RestRequest(command, Method.Post);


        //request.AddJsonBody(json);


        RestResponse? response = client.Post(request);

    }

}
