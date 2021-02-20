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
            for (int i = 0; i < 400000000; i++)
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
                .MaxBy(x => x.IntProperty); // Time complexity: O(n), Space complexity: O(1)
            
            Console.WriteLine(stopwatch.Elapsed);
        }
        
        [Test]
        public void OrderByDescendingAndFirstTests()
        {
            GC.Collect();
            stopwatch.Restart();

            var result = sampleCollection
                .OrderByDescending(x => x.IntProperty) // Time complexity: O(n*logn), Space complexity: O(log n)
                .First();
            
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}