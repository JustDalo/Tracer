using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tracer.Tracer.Methods;

namespace Tracer.Tracer.Threads
{
    public class ThreadInfo
    {  
        [XmlElement("id")]
        [JsonProperty("id")]
        public int ThreadId { get; set; }
        [XmlElement("time")]
        [JsonProperty("time")]
        public TimeSpan ThreadElapsedTime { get; set; }
        [XmlArray("methods")]
        [JsonProperty("methods")]
        public List<MethodInfo> MethodInfo { get; set; }

        public ThreadInfo()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            MethodInfo = new List<MethodInfo>();
        }
    }
}