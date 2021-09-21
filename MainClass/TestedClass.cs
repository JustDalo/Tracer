using Tracer.Tracer;

namespace MainClass
{
    public class TestedClass
    {
        private Bar _bar;
        private ITracer _tracer;

        internal TestedClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMathod();
            _tracer.StartTrace();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMathod()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }
    }
}