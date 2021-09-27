using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tracer.Tracer.Methods;

namespace Tracer.Tracer.Threads
{
    public class ResolveThread
    {
        [XmlElement("threadInformation")]
        [JsonProperty("thread information")]
        public ThreadInfo ThreadInfo { get; set; }
        private DateTime ThreadStartTime;
        private TraceMethod _methodInfo;
        
        [XmlIgnore]
        private Stack<TraceMethod> _methodStack;
        public ResolveThread()
        {
            _methodStack = new Stack<TraceMethod>();
            ThreadStartTime = DateTime.Now;
            ThreadInfo = new ThreadInfo();
        }

        public void StartThreadTrace()
        {
            _methodInfo = new TraceMethod();
            if (_methodStack.Count == 0)
            {
                ThreadInfo.MethodInfo.Add(_methodInfo.MethodInfo);
            }
            else
            {
                var oldMethod = _methodStack.Peek();
                oldMethod.MethodInfo.ChildMethods.Add(_methodInfo.MethodInfo);
            }
            _methodStack.Push(_methodInfo);
            _methodInfo.StartMethodTrace();
        }

        public void StopThreadTrace()
        {
            var method = _methodStack.Pop();
            
            _methodInfo.StopMethodTrace();
            ThreadInfo.ThreadElapsedTime = DateTime.Now - ThreadStartTime;
        }
        
        
    }
}