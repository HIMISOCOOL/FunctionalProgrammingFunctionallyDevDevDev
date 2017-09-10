using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
namespace CSharpFunctionally.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(params IEnumerable<T>[] lists)
        {
            return lists.SelectMany(x => x);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> src, params IEnumerable<T>[] lists)
        {
            return src.Concat(lists.SelectMany(x => x));
        }
    }
}
