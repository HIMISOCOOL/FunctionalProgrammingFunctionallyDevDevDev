using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

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
        public static List<string> DistinctPopularNames =
            PopularCatNamesAustralia.Concat(PopularCatNamesCanada)
            .Concat(PopularCatNamesGermany)
            .Concat(PopularCatNamesUK)
            .Distinct()
            .ToList();

        private static Random random = new Random();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static Cat GenerateCat()
        {
            return new Cat
            {
                Age = random.Next(0, 15),
                Id = ReferenceData.Guids.RandomSubset(1).Select(s => Guid.Parse(s)).First(),
                Name = DistinctPopularNames.RandomSubset(1).First()
            };
        }

        public static List<Cat> GenerateCats(int number)
        {
            return Enumerable.Range(0, number)
                .Select(i => GenerateCat())
                .ToList();
        }
    }
}
