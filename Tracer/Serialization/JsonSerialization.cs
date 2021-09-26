using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tracer.Tracer;
using Tracer.Tracer.Threads;


namespace Tracer.Serialization
{
    public class JsonSerialization : ISerialization
    {
        public JsonSerialization()
        {
            
        }

        public void SerializeTraceResult(TraceResult threadList)
        {
            int threadCount = 0;
            JsonMethod prevJsonMethod = null;
            
            JsonMain jsonMain = new JsonMain
            {
                Threads = new JsonThread[threadList.ThreadsList.Count],
            };
            foreach (var thread in threadList.ThreadsList)
            {
                JsonThread jsonThread = new JsonThread
                {
                    ThreadId = thread.ThreadInfo.ThreadId,
                    ThreadElapsedTime = thread.ThreadInfo.ThreadElapsedTime,
                    ThreadMethods = new JsonMethod(),
                };
                jsonMain.Threads[threadCount] = jsonThread;
                var methodCount = 0;
                foreach (var method in thread.ThreadInfo.MethodInfo)
                {
                    
                    JsonMethod jsonMethod = new JsonMethod
                    {
                        MethodName = method.MethodName,
                        ClassName = method.ClassName,
                        ElapsedTime = method.ElapsedTime,
                        ChildMethod = null,
                    };
                    
                    if (methodCount.Equals(0))
                    {
                        jsonThread.ThreadMethods = jsonMethod;
                    }
                    else
                    {
                        prevJsonMethod.ChildMethod = jsonMethod;
                    }

                    prevJsonMethod = jsonMethod;
                    methodCount++;
                    
                }

                threadCount++;
            }
            string json = JsonConvert.SerializeObject(jsonMain, Formatting.Indented);
            Console.WriteLine(json);
        }
    }

    internal class JsonMain
    {
        public JsonThread[] Threads;
    }
    internal class JsonThread
    {
        public int ThreadId;
        public TimeSpan ThreadElapsedTime;
        public JsonMethod ThreadMethods;
    }

    internal class JsonMethod
    {
        public string MethodName;
        public string ClassName;
        public TimeSpan ElapsedTime;
        public JsonMethod ChildMethod;
    }
}