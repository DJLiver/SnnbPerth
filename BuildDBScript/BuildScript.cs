using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BuildDBScript;
internal class BuildScript
{
    public static void go()
    {
        var j = File.ReadAllText(@"JsonText\RfOutputStream.json");

        Dictionary<string, string> RestRawDataTypes = new Dictionary<string, string>()
        {
            {"uint8", "[NUMERIC](5)" },
            {"uint16", "[NUMERIC](5)"},
            {"uint32", "[NUMERIC](10)"},
            {"uint64", "[NUMERIC](20)"},
            {"int8", "[int]"},
            {"int16", "[int]"},
            {"int32", "[int]"},
            {"int64", "[bigint]"},
            {"double", "[float]"},
            {"float", "[real]"},
            {"string", "[nvarchar](128)"},
            {"binary", "[nvarchar](MAX)"},
            {"bool", "[bit]"},
            {"time_duration", "[time]"},
            {"image", ""},
        };
        //"uint8", "uint16","uint32", "uint64",
        //"int8", "int16","int32", "int64",
        //"double", "float", "string", "binary", "bool","time_duration"};

        int level = 0;
        bool factoryTypeDetected = false;
        string sb = string.Empty;
        int lowerlevel = 1;
        int upperlevel = 2;

        using (JsonTextReader? reader = new JsonTextReader(new StringReader(j)))
        {
            while (reader.Read())
            {

                if (reader.TokenType == JsonToken.StartObject)
                {
                    level++;
                    continue;
                }
                if (reader.TokenType == JsonToken.EndObject)
                {
                    level--;
                    continue;
                }

                if (level == lowerlevel)
                {
                    sb = "\t[";
                    sb += reader.Value.ToString();
                    sb += "]";
                    //Console.Write("{0}, ", reader.Value);
                    continue;

                }
                if (level == upperlevel)
                {

                    if (factoryTypeDetected /*&& !reader.Value.ToString().Contains("[]")*/)
                    {
                        if (RestRawDataTypes.ContainsKey(reader.Value.ToString()))
                        //if(true)
                        {
                            sb += " ";
                            sb += RestRawDataTypes[reader.Value.ToString()];
                            sb += " NULL,";
                            Console.WriteLine(sb);
                            //Console.WriteLine("\t{0} - {1}", reader.Value, reader.Depth);
                        }
                        factoryTypeDetected = false;
                        continue;
                    }
                    if (reader.Value is not null)
                    {
                        if (reader.Value.ToString().Equals("factoryType"))
                        {
                            factoryTypeDetected = true;
                            continue;
                        }

                    }

                }
                //Console.WriteLine("{0} - {1}",
                //                  reader.TokenType, reader.Depth);
                //}
                //Console.WriteLine("{0} - {1} - {2}",
                //                  reader.TokenType, reader.ValueType, reader.Value);
            }
        }



    }
}
