using Tracer.Tracer.Methods;

namespace Tracer.Tracer.Threads
{
    public class ResolveThread
    {
        public ThreadInfo ThreadInfo { get; set; }
        private TraceMethod MethodInfo { get; set; }

        public ResolveThread()
        {
            ThreadInfo = new ThreadInfo();
        }

        public void StartThreadTrace()
        {
            MethodInfo = new TraceMethod();
            ThreadInfo.MethodInfo.Add(MethodInfo.MethodInfo);
            MethodInfo.StartMethodTrace();
        }

        public void StopThreadTrace()
        {
            MethodInfo.StopMethodTrace();
        }
        
    }
}