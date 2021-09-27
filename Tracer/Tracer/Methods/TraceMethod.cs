using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace Tracer.Tracer.Methods
{
    public class TraceMethod
    {
        private DateTime MethodStartTime { get; set; }
        public MethodInfo MethodInfo { get; set; }
       
        public TraceMethod()
        {
            MethodInfo = new MethodInfo();
            MethodInfo.MethodStartTime = DateTime.Now;
        }

        public void StartMethodTrace()
        {
            StackFrame frame = new StackFrame(3);
            var method = frame.GetMethod();
            MethodInfo.ClassName = method.DeclaringType.ToString();
            MethodInfo.MethodName = method.Name;
        }

        public void StopMethodTrace()
        {
            MethodInfo.ElapsedTime = DateTime.Now - MethodInfo.MethodStartTime;
        }
    }
    
}