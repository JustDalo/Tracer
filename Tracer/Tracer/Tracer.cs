using System;
using System.Collections.Generic;
using System.Threading;

namespace Tracer.Tracer
{
    public class Tracer : ITracer
    {
        private ResolveThread _resolveThread;
        private TraceResult _traceResult;
        private static object _locker;
        public Tracer()
        {
            _locker = new object();
            _traceResult = new TraceResult();
            
        }
        void ITracer.StartTrace()
        {
            _resolveThread = new ResolveThread();
            _resolveThread.StartThreadTrace();
        }

        void ITracer.StopTrace()
        {
            _resolveThread.StopThreadTrace();
        }

        TraceResult ITracer.GetTraceResult()
        {
            return null;
        }
    }
}