// See https://aka.ms/new-console-template for more information
using CommandTest;

Console.WriteLine("Hello, World!");
#pragma warning disable CS0219 // Variable is assigned but its value is never used
string RfOut = """{"rfOutputEnable": {"factory": "Attribute", "factoryType": "bool", "value": true }}""";

string configName = """{"name": {"factory": "Attribute", "factoryType": "string", "value": "default" }}""";


#pragma warning restore CS0219 // Variable is assigned but its value is never used

//RestData.GetSNWBConfig("http://10.228.41.151", "rest/configService/_procedure/downloadConfigFile", configName);



//RestData.GetConfigData("http://10.228.41.180", "rest/configService/_attribute?_dive=true");
//RestData.GetSysHealthData("http://10.228.41.151", "rest/systemHealth/_attribute?_dive=true");
//RestData.GetRestData("http://10.228.41.151", "rest/spectralNet/_attribute?_dive=true");
//RestData.GetRestData("http://10.228.41.151", "rest/configService/_attribute?_dive=true");
RestData.SetRestData("http://10.228.41.179", "/rest/spectralNet/_attribute/rfOutputEnable", RfOut);
