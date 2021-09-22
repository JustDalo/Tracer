using System;
using Tracer.Tracer;

namespace MainClass
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var tracer = new Tracer.Tracer.Tracer();
            var testedClass = new TestedClass(tracer);
            var bar = new Bar(tracer);
            testedClass.MyMethod();
            bar.InnerMethod();
        }
    }
}