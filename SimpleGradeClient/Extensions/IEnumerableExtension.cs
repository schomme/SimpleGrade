using System;
using System.Collections.Generic;

namespace SimpleGradeClient.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TSource> FlattenRecursive<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> getChildrenFunction)
        {
            return source;
        }
    }
}
