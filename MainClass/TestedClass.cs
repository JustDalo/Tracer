using System;
using System.Threading;
using Tracer.Tracer;

namespace MainClass
{
    public class Class1
    {
        private Class2 _class2;
        private Class3 _class3;
        private ITracer _tracer;

        public Class1(ITracer tracer)
        {
            _tracer = tracer;
            _class2 = new Class2(_tracer);
            _class3 = new Class3(_tracer);
        }

        public void Class1Method()
        {
            _tracer.StartTrace();
            _class2.Class2Method();
            _class3.Class3Method();
            _tracer.StopTrace();
        }
    }

    public class Class2
    {
        private Class3 _class3;
        private ITracer _tracer;

        public Class2(ITracer tracer)
        {
            _tracer = tracer;
            _class3 = new Class3(_tracer);
            
        }

        public void Class2Method()
        {
            _tracer.StartTrace();
            Thread thread = new Thread(_class3.Class3Method);
            thread.Start();
            thread.Join();
            _class3.Class3Method();
            _tracer.StopTrace();
        }
    }

    public class Class3
    {
        private ITracer _tracer;
        public Class3(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Class3Method()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
            _tracer.GetTraceResult();
        }
    }
}