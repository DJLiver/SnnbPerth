// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

using SnnbDB.Rest;

using TextToRest;

Console.WriteLine("Hello, World!");


using (var sr = new StreamReader("sn.json"))
{
    // Read the stream as a string, and write the string to the console.
    string s = sr.ReadToEnd();


   // Rootobject sNModule = JsonConvert.DeserializeObject<Rootobject>(s);

    RestMain sNModule = JsonConvert.DeserializeObject<RestMain>(s);


}
