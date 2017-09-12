using System;
using System.Collections.Generic;

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

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        static NonFunctionalCat()
        {
            foreach (var catName in PopularCatNamesAustralia)
            {
                if (!DistinctPopularNames.Contains(catName))
                {
                    DistinctPopularNames.Add(catName);
                }
            }
            foreach (var catName in PopularCatNamesUK)
            {
                if (!DistinctPopularNames.Contains(catName))
                {
                    DistinctPopularNames.Add(catName);
                }
            }
            foreach (var catName in PopularCatNamesGermany)
            {
                if (!DistinctPopularNames.Contains(catName))
                {
                    DistinctPopularNames.Add(catName);
                }
            }
            foreach (var catName in PopularCatNamesCanada)
            {
                if (!DistinctPopularNames.Contains(catName))
                {
                    DistinctPopularNames.Add(catName);
                }
            }
        }

        public NonFunctionalCat()
        {

        }

        public NonFunctionalCat(string name)
        {
            var randomIndex = random.Next(0, ReferenceData.Guids.Count);
            var randomGuidString = ReferenceData.Guids[randomIndex];
            var randomGuid = Guid.Parse(randomGuidString);

            Id = randomGuid;
            Age = 0;
            Name = name;
        }

        public static NonFunctionalCat GenerateCat()
        {
            var randomIndexGuid = random.Next(0, ReferenceData.Guids.Count);
            var randomGuidString = ReferenceData.Guids[randomIndexGuid];
            var randomGuid = Guid.Parse(randomGuidString);

            var randomIndexName = random.Next(0, DistinctPopularNames.Count);
            var randomName = DistinctPopularNames[randomIndexGuid];

            return new NonFunctionalCat
            {
                Age = random.Next(0, 15),
                Id = randomGuid,
                Name = randomName
            };
        }

        public static List<NonFunctionalCat> GenerateCats(int number)
        {
            var cats = new List<NonFunctionalCat>();

            for (int i = 0; i < number; i++)
            {
                var randomIndexGuid = random.Next(0, ReferenceData.Guids.Count);
                var randomGuidString = ReferenceData.Guids[randomIndexGuid];
                var randomGuid = Guid.Parse(randomGuidString);

                var randomIndexName = random.Next(0, DistinctPopularNames.Count);
                var randomName = DistinctPopularNames[randomIndexGuid];

                var cat = new NonFunctionalCat
                {
                    Age = random.Next(0, 15),
                    Id = randomGuid,
                    Name = randomName
                };

                cats.Add(cat);
            }

            return cats;
        }

        public static void MutateCat(NonFunctionalCat cat)
        {
            cat = null;
        }
        public static void MutateCat2(NonFunctionalCat cat)
        {
            cat = new NonFunctionalCat("Functional devs are hippies .!..");
        }
        public static void MutateCat3(NonFunctionalCat cat)
        {
            cat.Name = "Hah! Get hacked (╯°□°）╯︵ ┻━┻";
        }
    }
}
