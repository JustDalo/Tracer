using Tracer.Tracer;

namespace Tracer.Serialization
{
    public interface ISerialization
    {
        public void SerializeTraceResult(TraceResult threadList);
    }
}