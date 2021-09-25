using System;
using System.Collections.Generic;
using System.Threading;

namespace Tracer.Tracer
{
    public class Tracer : ITracer
    {
        private List<ResolveThread> ThreadList { get; set; }
        
        private TraceResult _traceResult;
        private static object _locker;
        public Tracer()
        {
            _locker = new object();
            _traceResult = new TraceResult();
            ThreadList = new List<ResolveThread>();
        }
        void ITracer.StartTrace()
        {
            ResolveThread thread = GetCurrentThread();
            if (thread == null)
            {
                thread = new ResolveThread();
                lock (_locker)
                {
                    ThreadList.Add(thread);
                }
            }
            thread.StartThreadTrace();
        }

        void ITracer.StopTrace()
        {
            ResolveThread thread = GetCurrentThread();
            thread.StopThreadTrace();
        }

        TraceResult ITracer.GetTraceResult()
        {
            return null;
        }

        private ResolveThread GetCurrentThread()
        {
            lock (_locker)
            {
                foreach (var thread in ThreadList)
                {
                    if (thread.ThreadInfo.ThreadId == Thread.CurrentThread.ManagedThreadId)
                    {
                        return thread;
                    }
                }
            }
            return null;
        }
    }
}