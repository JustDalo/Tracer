using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
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

        public void StopMethodTrace()
        {
            FinishedTime = DateTime.Now - StartTime;
            MethodInfo.ElapsedTime = FinishedTime.Milliseconds;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - " + FinishedTime);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - " + MethodInfo.ElapsedTime);
            Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            
            // Console.WriteLine(MethodInfo.ElapsedTime);
           // Console.WriteLine(MethodInfo.ClassName);
           // Console.WriteLine(MethodInfo.MethodName);
        }

        public MethodInfo GetMethodInfo()
        {
            return MethodInfo;
        }
    }
    
}