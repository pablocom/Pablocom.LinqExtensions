using System;
using System.Collections;
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
                if (selector(item).CompareTo(selector(max)) == 1)
                    max = item;

            return max;
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> collection)
        {
            if (!collection.Any())
                return true;

            return false;
        }
    }
}