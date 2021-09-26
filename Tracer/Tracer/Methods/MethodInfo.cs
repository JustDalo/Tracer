using System;

namespace Tracer.Tracer.Methods
{
    public class MethodInfo
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}