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
            class2Thread.Start();
            Thread class3Thread = new Thread(new ThreadStart(class3.Class3Method));
            class3Thread.Start();
            class1.Class1Method();
            class3.Class3Method();
            TraceResult traceResult = tracer.GetTraceResult();
            var json = new XmlSerialization();
            json.SerializeTraceResult(traceResult);
        }
    }
}