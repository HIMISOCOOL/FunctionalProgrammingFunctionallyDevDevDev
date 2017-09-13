using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public static IEnumerable<T> AppendTo<T>(this IEnumerable<T> source, List<T> target)
        {
            target.AddRange(source);
            return target;
        }

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
             IEnumerable<TSource> second,
             Func<TSource, TKey> keySelector,
             IEqualityComparer<TKey> keyComparer)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return ExceptKeysImpl(first, second.Select(keySelector), keySelector, keyComparer);
        }

        public static IEnumerable<TSource> ExceptKeys<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TKey> second,
            Func<TSource, TKey> keySelector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return ExceptKeysImpl(first, second, keySelector, null);
        }

        public static IEnumerable<TSource> ExceptKeys<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return ExceptKeysImpl(first, second, keySelector, keyComparer);
        }

        private static IEnumerable<TSource> ExceptKeysImpl<TSource, TKey>(IEnumerable<TSource> first,
            IEnumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            var keys = new HashSet<TKey>(second, keyComparer);
            foreach (var element in first)
            {
                var key = keySelector(element);
                if (keys.Add(key))
                    yield return element;
            }
        }

        [DebuggerStepThrough]
        public static bool HasContent<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> PipeAll<T>(this IEnumerable<T> source, Action<IEnumerable<T>> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            return _(); IEnumerable<T> _()
            {
                var sourceList = source.ToList();

                action(sourceList);
                return sourceList;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> PipeAll<T>(this IReadOnlyList<T> source, Action<IEnumerable<T>> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            return _(); IEnumerable<T> _()
            {
                action(source);
                return source;
            }
        }

        [DebuggerStepThrough]
        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            if (tasks == null) throw new ArgumentNullException(nameof(tasks));

            return Task.WhenAll(tasks);
        }

        /// <summary>
        /// !Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        [DebuggerStepThrough]
        public static bool NullOrNone<TSource>(this IEnumerable<TSource> source)
        {
            return source != null
                && !source.Any();
        }

        /// <summary>
        /// !Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return !source.Any(predicate);
        }

        /// <summary>
        /// Returns true if everything in sequence is distinct where "distinctness"
        /// is determined via the default equality comparer for the type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool AllDistinct<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var hashSet = new HashSet<TSource>();
            return source.All(hashSet.Add);
        }

        /// <summary>
        /// Returns true if everything in sequence is distinct where "distinctness"
        /// is determined via a projection and the default equality comparer for the projected type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool AllDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return source.AllDistinctBy(keySelector, null);
        }

        /// <summary>
        /// Returns true if everything in sequence is distinct where "distinctness"
        /// is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool AllDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return source
                .DistinctBy(keySelector, comparer)
                .AllDistinct();
        }
    }
}
