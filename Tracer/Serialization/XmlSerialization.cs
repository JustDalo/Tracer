using System;
using System.IO;
using System.Xml.Serialization;
using Tracer.Tracer;
using Tracer.Tracer.Methods;
using Tracer.Tracer.Threads;

namespace Tracer.Serialization
{
    public class XmlSerialization : ISerialization
    {
        public void SerializeTraceResult(TraceResult threadList)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(TraceResult));
            using (FileStream fs = new FileStream(@"d:\TraceResult.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, threadList);
 
                Console.WriteLine("Объект сериализован");
            }
        }
    }
}