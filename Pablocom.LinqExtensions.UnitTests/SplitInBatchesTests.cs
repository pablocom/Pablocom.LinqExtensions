using NUnit.Framework;
using System;
using System.Linq;

namespace Pablocom.LinqExtensions.UnitTests
{
    [TestFixture]
    public class SplitInBatchesTests
    { 
        [Test]
        public void SplitsArrayOfNumbers()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            var batches = numbers.SplitToBatches(2).ToArray();

            Assert.That(batches, Has.Length.EqualTo(3));
            CollectionAssert.AreEquivalent(batches[0], new[] { 1, 2 });
            CollectionAssert.AreEquivalent(batches[1], new[] { 3, 4 });
            CollectionAssert.AreEquivalent(batches[2], new[] { 5 });
        }

        [Test]
        public void DoesNotReturnAnyBatchWhenSplittingAnEmptyArray()
        {
            var numbers = new int[0];

            var batches = numbers.SplitToBatches(1).ToArray();

            Assert.That(batches, Has.Length.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsExceptionIfBatchSizeIsLessOrEqualThanZero(int batchSize)
        {
            var numbers = new int[0];

            TestDelegate action = () => numbers.SplitToBatches(batchSize).ToArray();

            Assert.Throws<InvalidOperationException>(action, "Batch size cannot be less than or equal to 0");
        }
    }
}