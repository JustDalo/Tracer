using Tracer.Tracer;

namespace Tracer.Serialization
{
    public interface ISerialization
    {
        public string SerializeTraceResult(TraceResult threadList);
    }
}