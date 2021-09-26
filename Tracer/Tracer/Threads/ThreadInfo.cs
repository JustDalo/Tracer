using System;
using System.Collections.Generic;
using System.Threading;
using Tracer.Tracer.Methods;

namespace Tracer.Tracer.Threads
{
    public class ThreadInfo
    {
        public int ThreadId { get; set; }
        public TimeSpan ThreadElapsedTime { get; set; }
        public List<MethodInfo> MethodInfo { get; set; }

        public ThreadInfo()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            MethodInfo = new List<MethodInfo>();
        }
    }
}