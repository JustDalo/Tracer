using System.Collections.Generic;
using System.Threading;
using Tracer.Tracer.Threads;

namespace Tracer.Tracer
{
    public class Tracer : ITracer
    {
        private List<ResolveThread> ThreadList { get; set; }
        private static object _locker;
        public Tracer()
        {
            _locker = new object();
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

        public TraceResult GetTraceResult()
        {
            TraceResult traceResult = new TraceResult(ThreadList);
            return traceResult;
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