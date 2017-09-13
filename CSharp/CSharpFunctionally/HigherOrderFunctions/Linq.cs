using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionally.HigherOrderFunctions
{
    public class Linq
    {
        private static Random random = new Random(Guid.NewGuid().GetHashCode());
        private static int[] numbers = Enumerable.Range(0, 1000)
            .Select(i => random.Next(-1000, 1000))
            .ToArray();

        public static void DemoFilter()
        {
            int[] evens = numbers
                .Where(i => i % 2 == 0)
                .ToArray();
        }

        public static void DemoAllAndAny()
        {
            bool allPositive = numbers
                .All(i => i > 0);

            bool anyPositive = numbers
                .Any(i => i > 0);
        }

        public static void DemoSelect()
        {
            int[] transformed = numbers
                .Take(10)
                .Select(i => i * 10)
                .ToArray();
        }

        public static void DemoSelectMany()
        {
            Cat[][] cats = new Cat[8][]
            {
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
                Cat.GenerateCats(random.Next(10)),
            };

            IEnumerable<Cat> catsFlat = cats
                .SelectMany(catArray => catArray)
                .ToArray();
        }

        public static void DemoAggregate()
        {
            int maxAggregate = numbers
                .Aggregate(int.MinValue, (previous, current) => 
                    previous > current 
                    ? previous 
                    : current);

            int max = numbers.Max();
            int min = numbers.Min();
            double average = numbers.Average();
        }
        internal static void DemoOrderBy()
        {
            int[] orderedAscending = numbers
                .Take(10)
                .OrderBy(i => i)
                .ToArray();

            int[] orderedDescending = numbers
                .Take(10)
                .OrderByDescending(i => i)
                .ToArray();
        }

        internal static void DemoExceptIntersect()
        {
            int[] randomSequence = Enumerable.Range(0, 100)
                .Select(i => random.Next(0, 50))
                .ToArray();

            int[] intersection = numbers
                .Intersect(randomSequence)
                .ToArray();

            int[] except = randomSequence
                .Except(numbers)
                .ToArray();
        }

    }
}
