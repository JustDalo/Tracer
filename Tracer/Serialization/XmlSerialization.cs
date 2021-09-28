using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Tracer.Tracer;

namespace Tracer.Serialization
{
    public class XmlSerialization : ISerialization
    {
        public string SerializeTraceResult(TraceResult threadList)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(TraceResult));
            string xml = "";
            using (var sww = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    formatter.Serialize(writer, threadList);
                    xml = sww.ToString();
                    
                }
            }

            return xml;
        }
    }
}