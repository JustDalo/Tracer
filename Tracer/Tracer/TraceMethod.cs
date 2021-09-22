using System;
using System.Data;
using System.Diagnostics;
using System.Timers;

namespace Tracer.Tracer
{
    public class TraceMethod
    {
        private DateTime StartTime { get; set; }
        private TimeSpan FinishedTime { get; set; }
        private MethodInfo MethodInfo { get; set; }
        public TraceMethod()
        {
            MethodInfo = new MethodInfo();
        }

        public void StartMethodTrace()
        {
            StackFrame frame = new StackFrame(2);
            var method = frame.GetMethod();
            this.StartTime = DateTime.Now;
            MethodInfo.ClassName = method.DeclaringType.ToString();
            MethodInfo.MethodName = method.Name;
        }

        public MethodInfo StopMethodTrace()
        {
            FinishedTime = DateTime.Now - StartTime;
            MethodInfo.ElapsedTime = FinishedTime;
            
            Console.WriteLine(MethodInfo.ElapsedTime);
            Console.WriteLine(MethodInfo.ClassName);
            Console.WriteLine(MethodInfo.MethodName);
            return MethodInfo;
        }

        private string GetCurrentClassName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(3);

            return stackFrame.GetMethod().DeclaringType.ToString();
        }
        private string GetCurrentMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(2);

            return stackFrame.GetMethod().Name;
        }
    }
    
}