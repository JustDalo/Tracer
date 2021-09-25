using System;
using System.Collections.Generic;

namespace Tracer.Tracer
{
    public class TraceResult
    {
        public int Id { get; set; }
        public TimeSpan ThreadTime { get; set; }
        public List<MethodInfo> ChildMethod { get; set; } 
    }

    public class MethodNode
    {
        public List<MethodInfo> ChildMethod { get; set; }
    }
}