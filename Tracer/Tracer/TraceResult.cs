using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tracer.Tracer.Threads;

namespace Tracer.Tracer
{
    public class TraceResult
    {
        public IReadOnlyList<ResolveThread> ThreadsList;
      
        public TraceResult(List<ResolveThread> threadsList)
        {
            ThreadsList = new ReadOnlyCollection<ResolveThread>(threadsList);
        }
        
    }
}