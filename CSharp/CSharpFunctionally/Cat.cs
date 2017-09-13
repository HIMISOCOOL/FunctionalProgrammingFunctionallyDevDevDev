using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using CSharpFunctionally.Extensions;

namespace CSharpFunctionally
{
    public class Cat
    {
        public static List<string> PopularCatNamesAustralia = new List<string>
        {
            "Ashes",
            "Tiger",
            "Puss",
            "Smokey",
            "Misty",
            "Tigger",
            "Kitty",
            "Oscar",
            "Missy",
            "Max",
            "Ginger",
        };
        public static List<string> PopularCatNamesUK = new List<string>
        {
            "Ashes",
            "Molly",
            "Charlie",
            "Tigger",
            "Poppy",
            "Oscar",
            "Smudge",
            "Millie",
            "Daisy",
            "Max",
            "Jasper",
            "Trevor",
        };
        public static List<string> PopularCatNamesGermany = new List<string>
        {
            "Ashes",
            "Felix",
            "Minka",
            "Moritz",
            "Charly",
            "Tiger",
            "Eve",
            "Susi",
            "Lisa",
            "Blacky",
            "Muschi",
        };
        public static List<string> PopularCatNamesCanada = new List<string>
        {
            "Ashes",
            "Minou",
            "Grisou",
            "Ti-Mine",
            "Félix",
            "Caramel",
            "Mimi",
            "Pacha",
            "Charlotte",
            "Minette",
            "Chanel",
        };

        // Power of expression!
        public static IEnumerable<string> DistinctPopularNames =
            EnumerableExtensions.Concat(
                PopularCatNamesAustralia,
                PopularCatNamesCanada,
                PopularCatNamesGermany,
                PopularCatNamesUK)
            .Distinct();

        private static Random random = new Random();

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }


        private Cat(){}
        public Cat(string name): this(name, 0){}
        public Cat(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }


        public static Cat GenerateCat()
        {
            return new Cat
            {
                Age = random.Next(0, 15),
                Id = Guid.Parse(ReferenceData.Guids.Random(random)),
                Name = PopularCatNamesAustralia.Random(random)
            };
        }

        public static Cat[] GenerateCats(int number)
        {
            return Enumerable.Range(0, number)
                .Select(i => GenerateCat())
                .ToArray();
        }
    }
}
