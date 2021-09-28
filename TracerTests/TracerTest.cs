using System.Threading;
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
            _tracer = new Tracer.Tracer.Tracer();
            _class1 = new Class1(_tracer);
            _class2 = new Class2(_tracer);
            _class3 = new Class3(_tracer);
        }

        [Test]
        public void Test1()
        {   
            _class1.Class1Method();
            var result = _tracer.GetTraceResult();
            Assert.AreEqual(2, result.ThreadsList.Count);
        }
        [Test]
        public void Test2()
        {
            _class1.Class1Method();
            _class2.Class2Method();
            var result = _tracer.GetTraceResult();
            Assert.AreEqual(3, result.ThreadsList.Count);
        }

        [Test]
        public void Test3()
        {
            Thread class2Thread = new Thread(new ThreadStart(_class2.Class2Method));
            Thread class3Thread = new Thread(new ThreadStart(_class3.Class3Method));
            class2Thread.Start();
            class3Thread.Start();
            class2Thread.Join();
            class3Thread.Join();
            var result = _tracer.GetTraceResult();
            Assert.AreEqual(3, result.ThreadsList.Count);
        }
        
    }
    public class Class1
    {
        private Class2 _class2;
        private Class3 _class3;
        private ITracer _tracer;

        public Class1(ITracer tracer)
        {
            _tracer = tracer;
            _class2 = new Class2(_tracer);
            _class3 = new Class3(_tracer);
        }

        public void Class1Method()
        {
            _tracer.StartTrace();
            _class2.Class2Method();
            _class3.Class3Method();
            _tracer.StopTrace();
        }
    }

    public class Class2
    {
        private Class3 _class3;
        private ITracer _tracer;

        public Class2(ITracer tracer)
        {
            _tracer = tracer;
            _class3 = new Class3(_tracer);
            
        }

        public void Class2Method()
        {
            _tracer.StartTrace();
            Thread thread = new Thread(_class3.Class3Method);
            thread.Start();
            thread.Join();
            _class3.Class3Method();
            _tracer.StopTrace();
        }
    }

    public class Class3
    {
        private ITracer _tracer;
        public Class3(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Class3Method()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
            _tracer.GetTraceResult();
        }
    }
}