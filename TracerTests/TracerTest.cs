using MainClass;
using NUnit.Framework;
using Tracer.Tracer;

namespace TracerTests
{
    public class Tests
    {
        private ITracer _tracer;
        public Class1 _class1;
        private Class2 _class2;
        private Class3 _class3;
        [SetUp]
        public void Setup()
        {
            var tracer = new Tracer.Tracer.Tracer();
            var class1 = new Class1(tracer);
            var class2 = new Class2(tracer);
            var class3 = new Class3(tracer);
        }

        [Test]
        public void Test1()
        {   
            _class1.Class1Method();
        }
    }
}