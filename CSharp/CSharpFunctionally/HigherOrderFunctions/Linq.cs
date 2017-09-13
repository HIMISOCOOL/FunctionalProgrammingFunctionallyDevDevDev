using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionally.HigherOrderFunctions
{
    public class Linq
    {
        public static void DemoFilter()
        {
            List<int> evens = Enumerable.Range(0, 10)
                .Where(i => i % 2 == 0)
                .ToList();
        }

        public static void DemoSelect()
        {
            List<int> transformed = Enumerable.Range(0, 10)
                .Select(i => i * 10)
                .ToList();
        }

        public static void DemoAll()
        {
            Random random = new Random();

            bool allPositive = Enumerable.Range(0, 100)
                .Select(i => random.Next(-100, 100))
                .All(i => i > 0);
        }

        public static void SelectMany()
        {
            Cat[][] cats = new Cat[8][];

            Cat[] catsFlat = cats
                .SelectMany(catArray => catArray)
                .ToArray();
        }

    }
}
