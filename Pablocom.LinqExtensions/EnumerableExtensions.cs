using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pablocom.LinqExtensions
{
    public static class DummyEnumerableExtensions
    {
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> selector)
            where TKey : IComparable
        {
            if (collection.IsEmpty())
                throw new InvalidOperationException("Sequence contains no elements");
            
            var source = collection.ToArray();
            var maxObject = source.First();
            var positionFound = 0;

            for (var i = 0; i < source.Length; i++)
            {
                var item = source[i];
                
                if (selector(item).CompareTo(selector(maxObject)) == 1)
                {
                    maxObject = item;
                    positionFound = i;
                }
            }

            return source[positionFound];
        }

        public static bool IsEmpty<TSource>(this IEnumerable<TSource> collection)
        {
            if (!collection.Any())
                return true;

            return false;
        }
    }
}