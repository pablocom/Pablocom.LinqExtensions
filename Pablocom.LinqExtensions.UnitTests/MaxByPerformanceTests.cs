using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Pablocom.LinqExtensions.UnitTests
{
    [TestFixture]
    public class MaxByPerformanceTests
    {
        private Random random = new Random();
        private List<Dummy> sampleCollection = new List<Dummy>();
        private Stopwatch stopwatch = new Stopwatch();

        public MaxByPerformanceTests()
        {
            for (int i = 0; i < 4000000; i++)
            {
                sampleCollection.Add(new Dummy(random.Next(-100000, 100000)));
            }
        }

        [Test]
        public void MaxByTests()
        {
            GC.Collect();
            stopwatch.Restart();

            var result = sampleCollection
                .MaxBy(x => x.IntProperty);
            
            Console.WriteLine(stopwatch.Elapsed);
        }
        
        [Test]
        public void OrderByDescendingAndFirstTests()
        {
            GC.Collect();
            stopwatch.Restart();

            var result = sampleCollection
                .OrderByDescending(x => x.IntProperty) 
                .First();
            
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}