using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Tracer.Tracer.Threads;

namespace Tracer.Tracer
{
    public class TraceResult
    {
        [XmlArray("threads")]
        public List<ResolveThread> ThreadsList;

        public TraceResult()
        {
            
        }
        public TraceResult(List<ResolveThread> threadsList)
        {
            ThreadsList = new List<ResolveThread>(threadsList);
        }

        public void Add(ResolveThread T)
        {
            
        }

    }
}