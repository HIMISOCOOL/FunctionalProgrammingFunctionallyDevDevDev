using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using CSharpFunctionally.Extensions;

namespace CSharpFunctionally
{
    public class NonFunctionalCat
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

        public static List<string> DistinctPopularNames = new List<string>();

        private static Random random = new Random();

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public NonFunctionalCat(string name)
        {
            var randomIndex = random.Next(0, ReferenceData.Guids.Count);
            var randomGuidString = ReferenceData.Guids[randomIndex];
            var randomGuid = Guid.Parse(randomGuidString);

            Id = randomGuid;
            Age = 0;
            Name = name;
        }

        public static Cat GenerateCat()
        {
            var randomIndexGuid = random.Next(0, ReferenceData.Guids.Count);
            var randomGuidString = ReferenceData.Guids[randomIndexGuid];
            var randomGuid = Guid.Parse(randomGuidString);

            var randomIndexName = random.Next(0, DistinctPopularNames.Count);
            var randomName = DistinctPopularNames[randomIndexGuid];

            return new Cat
            {
                Age = random.Next(0, 15),
                Id = randomGuid,
                Name = randomName
            };
        }

        public static List<Cat> GenerateCats(int number)
        {
            var cats = new List<Cat>();

            for (int i = 0; i < number; i++)
            {
                var randomIndexGuid = random.Next(0, ReferenceData.Guids.Count);
                var randomGuidString = ReferenceData.Guids[randomIndexGuid];
                var randomGuid = Guid.Parse(randomGuidString);

                var randomIndexName = random.Next(0, DistinctPopularNames.Count);
                var randomName = DistinctPopularNames[randomIndexGuid];

                var cat = new Cat
                {
                    Age = random.Next(0, 15),
                    Id = randomGuid,
                    Name = randomName
                };

                cats.Add(cat);
            }

            return cats;
        }
    }

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
            EnumerableExtensions.Concat(
                PopularCatNamesAustralia,
                PopularCatNamesCanada,
                PopularCatNamesGermany,
                PopularCatNamesUK)
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
