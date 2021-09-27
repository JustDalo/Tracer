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
            File.WriteAllText(@"d:\TraceResult.json", JsonConvert.SerializeObject(threadList));
            
            using (StreamWriter file = File.CreateText(@"d:\TraceResult.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, threadList);
            }
        }
    }
}