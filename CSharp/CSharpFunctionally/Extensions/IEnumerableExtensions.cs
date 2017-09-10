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

        public static T Random<T>(this IEnumerable<T> src, Random random)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            return src.ToList().Random(random);
        }

        public static T Random<T>(this IList<T> src, Random random)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            return src.ElementAt(random.Next(0, src.Count));
        }
    }
}
