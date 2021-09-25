using System;
using System.Collections.Generic;

namespace Tracer.Tracer
{
    public class TraceResult
    {
        public List<ThreadInfo> ThreadsInfo { get; set; }
        public List<MethodInfo> ChildMethod { get; set; }

        public TraceResult()
        {
            ThreadsInfo = new List<ThreadInfo>();
            
        }
    }
    
    

    public class MethodNode
    {
        public List<MethodInfo> ChildMethod { get; set; }
    }
}