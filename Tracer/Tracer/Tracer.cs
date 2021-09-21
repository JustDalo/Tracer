namespace Tracer.Tracer
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        TraceResult GetTraceResult();
    }
    public class Tracer : ITracer
    {
        void ITracer.StartTrace()
        {
            
        }

        void ITracer.StopTrace()
        {
            
        }

        TraceResult ITracer.GetTraceResult()
        {
            return null;
        }
    }
}