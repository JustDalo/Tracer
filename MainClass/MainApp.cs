using System;
using System.Threading;
using Tracer.Tracer;

namespace MainClass
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var tracer = new Tracer.Tracer.Tracer();
            var testedClass = new Foo(tracer);
            var bar = new Bar(tracer);
           
            testedClass.MyMethod();
            Thread t = new Thread(new ThreadStart(bar.InnerMethod));
           
            t.Start();
            
            

        }
    }
}