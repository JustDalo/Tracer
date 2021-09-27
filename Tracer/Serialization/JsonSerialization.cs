using System;
using System.Text.Json;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tracer.Tracer;
using Tracer.Tracer.Threads;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace Tracer.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public JsonSerialization()
        {
            
        }
        
        public void SerializeTraceResult(TraceResult threadList)
        {
            string json = JsonConvert.SerializeObject(threadList, Formatting.Indented);

            Console.WriteLine(json);
            File.WriteAllText(@"d:\TraceResult.json", JsonConvert.SerializeObject(threadList, Formatting.Indented));
            
            using (StreamWriter file = File.CreateText(@"d:\TraceResult.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, JsonConvert.SerializeObject(threadList, Formatting.Indented));
            }
        }
    }
}