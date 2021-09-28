using System;
using System.IO;

namespace Tracer.Serialization
{
    public class ResultWriter
    {
        public void WriteResult(string result, string filepath)
        {
            Console.WriteLine(result);
            using StreamWriter writer = new StreamWriter(filepath);
            writer.Write(result);
        }
    }
}