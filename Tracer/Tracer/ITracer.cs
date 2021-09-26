namespace Tracer.Tracer
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        public TraceResult GetTraceResult();
    }
}