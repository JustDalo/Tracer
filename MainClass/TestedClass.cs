using System;
using Tracer.Tracer;

namespace MainClass
{
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            _tracer.StopTrace();
           // _tracer.GetTraceResult();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
           
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            int x = 1;
            for (int i = 0; i < 1000; i++)
            {
                x = i * i;
            }
            _tracer.StopTrace();
           // Console.WriteLine(_tracer.GetTraceResult());
        }
    }
}