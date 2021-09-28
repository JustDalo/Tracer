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
        
        public string SerializeTraceResult(TraceResult threadList)
        {
            string json = JsonConvert.SerializeObject(threadList, Formatting.Indented);
            return json;
        }
    }
}