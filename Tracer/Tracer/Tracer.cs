using System;

namespace Tracer.Tracer
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        TraceResult GetTraceResult();
    }
    public class Tracer : ITracer
    {
        private TraceMethod resolveMethod;
        public Tracer()
        {
            
        }
        void ITracer.StartTrace()
        {
            resolveMethod = new TraceMethod();
            resolveMethod.StartMethodTrace();
        }

        void ITracer.StopTrace()
        {
            resolveMethod.StopMethodTrace();
        }

        TraceResult ITracer.GetTraceResult()
        {
            return null;
        }
    }
}