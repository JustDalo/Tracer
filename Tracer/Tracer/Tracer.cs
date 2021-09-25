using System;
using System.Collections.Generic;
using System.Threading;

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
        private List<TraceMethod> _MethodTrace; 
        private TraceMethod resolveMethod;
        private TraceResult _traceResult;
        public Tracer()
        {
            _MethodTrace = new List<TraceMethod>();
            _traceResult = new TraceResult();
        }
        void ITracer.StartTrace()
        {
            resolveMethod = new TraceMethod();
            _MethodTrace.Add(resolveMethod);
            resolveMethod.StartMethodTrace();
        }

        void ITracer.StopTrace()
        {
            resolveMethod.StopMethodTrace();
       
           
        }

        TraceResult ITracer.GetTraceResult()
        {
            _traceResult.Id = Thread.CurrentThread.ManagedThreadId;
            _traceResult.ChildMethod.Add(resolveMethod.GetMethodInfo());
            return _traceResult;
        }
    }
}