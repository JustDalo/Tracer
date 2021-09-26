using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tracer.Tracer;
using Tracer.Tracer.Threads;


namespace Tracer.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public JsonSerialization()
        {
            
        }

        public void SerializeTraceResult(TraceResult threadList)
        {
            Console.WriteLine(threadList.ThreadsList);
            TraceJson jsonResults = new TraceJson
            {
                ThreadId = 1,
            };

            string json = JsonConvert.SerializeObject(jsonResults, Formatting.Indented);
            Console.Write(json);
        }
        
        
    }

    internal class TraceJson
    {
        public int ThreadId;
        public TimeSpan ThreadElapsetTime;
        
    }
}