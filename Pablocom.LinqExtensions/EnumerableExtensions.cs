using System;
using System.Collections.Generic;
using System.Linq;

namespace Pablocom.LinqExtensions
{
    public static class EnumerableExtensions
    {
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> selector)
            where TKey : IComparable<TKey>
        {
            if (collection.IsEmpty())
                throw new InvalidOperationException("Sequence contains no elements");
            
            var max = collection.First();
            foreach (var item in collection)
            {
                if (selector(item).CompareTo(selector(max)) > 0)
                    max = item;
            }

            return max;
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> collection) => !collection.Any();

        public static IEnumerable<IEnumerable<TSource>> SplitToBatches<TSource>(this IEnumerable<TSource> items, int batchSize)
        {
            if (batchSize <= 0)
                throw new InvalidOperationException("Batch size cannot be less than or equal to 0");

            var itemsCount = items.Count();
            var offset = 0;

            while (offset + batchSize <= itemsCount)
            {
                yield return items.Skip(offset).Take(batchSize);
                offset += batchSize;
            }

            if (offset < itemsCount)
                yield return new[] { items.Last() };
        }
    }
}