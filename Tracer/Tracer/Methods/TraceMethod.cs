using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace Tracer.Tracer.Methods
{
    public class TraceMethod
    {
       
        public MethodInfo MethodInfo { get; set; }
       
        public TraceMethod()
        {
            MethodInfo = new MethodInfo();
            MethodInfo.MethodStartTime = DateTime.Now;
        }

        public void StartMethodTrace(MethodInfo methodInfo)
        {
            StackFrame frame = new StackFrame(3);
            var method = frame.GetMethod();
            methodInfo.ClassName = method.DeclaringType.ToString();
            methodInfo.MethodName = method.Name;
        }

        public void StopMethodTrace(MethodInfo methodInfo)
        {
            var finishedTime = DateTime.Now - MethodInfo.MethodStartTime;
            methodInfo.ElapsedTime = DateTime.Now - MethodInfo.MethodStartTime;
        }
    }
    
}