using System;
using System.Threading;
using Tracer.Serialization;
using Tracer.Tracer;

namespace MainClass
{
    class MainApp
    {
        private static void Main(string[] args)
        {
            var tracer = new Tracer.Tracer.Tracer();
            var class1 = new Class1(tracer);
            var class2 = new Class2(tracer);
            var class3 = new Class3(tracer);
            Thread class2Thread = new Thread(new ThreadStart(class2.Class2Method));
            
            Thread class3Thread = new Thread(new ThreadStart(class3.Class3Method));
            class3Thread.Start();
            class2Thread.Start();
            class2Thread.Join();
            class3Thread.Join();
            class1.Class1Method();
            
            TraceResult traceResult = tracer.GetTraceResult();
            var xml = new XmlSerialization();
            var json = new JsonSerialization();
            
            var writer = new ResultWriter();
            writer.WriteResult(json.SerializeTraceResult(traceResult), @"d:\TraceResult.json");
            writer.WriteResult(xml.SerializeTraceResult(traceResult), @"d:\TraceResult.xml");
        }
    }
}