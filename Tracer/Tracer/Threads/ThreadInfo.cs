using System.Collections.Generic;
using System.Threading;

namespace Tracer.Tracer
{
    public class ThreadInfo
    {
        public int ThreadId { get; set; }
        public int ThreadElapsedTime { get; set; }
        public List<MethodInfo> MethodInfo { get; set; }

        public ThreadInfo()
        {
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            MethodInfo = new List<MethodInfo>();
        }
    }
}