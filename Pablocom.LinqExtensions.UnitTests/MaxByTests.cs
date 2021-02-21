using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Pablocom.LinqExtensions.UnitTests
{
    [TestFixture]
    public class MaxByTests
    {
        [Test]
        public void ThrowsInvalidOperationExceptionIfContainsNoElements()
        {
            var emptyCollection = new List<string>();

            TestDelegate testDelegate = () => emptyCollection.MaxBy(x => x);

            Assert.Throws<InvalidOperationException>(testDelegate, "Sequence contains no elements");
        }
        
        [Test]
        public void GetMaximumByProperty()
        {
            var expected = new Dummy(17);
            var collection = new List<Dummy>
            {
                new Dummy(2),
                new Dummy(4),
                new Dummy(8),
                new Dummy(16),
                new Dummy(-4),
                expected,
                new Dummy(15)
            };
        
            var maxByProperty = collection.MaxBy(x => x.IntProperty);

            Assert.That(maxByProperty.IntProperty, Is.EqualTo(expected.IntProperty));
            Assert.That(maxByProperty, Is.EqualTo(expected));
        }
        
        [Test]
        public void GetMaximumByStringLength()
        {
            var expected = "afqwerfqwer";
            var collection = new List<string>
            {
                "a",
                "aasdf",
                "afawer",
                expected,
                "aqwerqwe",
            };
        
            var maxByProperty = collection.MaxBy(x => x.Length);
        
            Assert.That(maxByProperty.Length, Is.EqualTo(expected.Length));
            Assert.That(maxByProperty, Is.EqualTo(expected));
        }
    }
}