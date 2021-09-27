using System;
using System.Collections.Generic;

namespace Tracer.Tracer.Methods
{
    public class MethodInfo
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public DateTime MethodStartTime { get; set; }
        
        public List<MethodInfo> ChildMethods { get; set; }

        public MethodInfo()
        {
            ChildMethods = new List<MethodInfo>();
        }
    }
}