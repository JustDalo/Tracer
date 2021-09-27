using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer.Tracer.Methods
{
    public class MethodInfo
    {
        [XmlElement("class")]
        [JsonProperty("class")]
        public string ClassName { get; set; }
        [XmlElement("name")]
        [JsonProperty("name")]
        public string MethodName { get; set; }
        [XmlElement("time")]
        [JsonProperty("time")]
        public TimeSpan ElapsedTime { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public DateTime MethodStartTime { get; set; }
        [XmlArray("methods")]
        [JsonProperty("methods")]
        
        public List<MethodInfo> ChildMethods { get; set; }

        public MethodInfo()
        {
            ChildMethods = new List<MethodInfo>();
        }
    }
}