using System;

namespace Tracer.Tracer
{
    public class ResolveThread
    {
        private ThreadInfo ThreadInfo { get; set; }
        private int ThreadElapsedTime { get; set; }
        private DateTime StartTime { get; set; }
        
        public ResolveThread()
        {
            ThreadInfo = new ThreadInfo();
        }

        public void StartThreadTrace()
        {
            StartTime = DateTime.Now;
            
        }

        public void StopThreadTrace()
        {
            var finishedTime = DateTime.Now - StartTime;
            ThreadInfo.ThreadElapsedTime = finishedTime.Milliseconds;
            
        }
        
    }
}