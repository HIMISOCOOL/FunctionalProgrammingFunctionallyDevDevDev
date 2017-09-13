using CSharpFunctionally.HigherOrderFunctions;
using CSharpFunctionally.Immutability;
using System;
using System.Linq;

namespace CSharpFunctionally
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoImmutability();
            DemoHigherOrderFunctions();
        }

        private static void DemoImmutability()
        {
            var demo = new KindsOfImmutability();
            demo.Mutate();

            var cat = new NonFunctionalCat("Arnold");
            NonFunctionalCat.MutateCat(cat);
            Console.WriteLine(cat.Name);

            NonFunctionalCat.MutateCat2(cat);
            Console.WriteLine(cat.Name);

            NonFunctionalCat.MutateCat3(cat);
            Console.WriteLine(cat.Name);

            var dataStructures = new DataStructures();

            dataStructures.ImmutableStackCanShareState();

            dataStructures.OddBehaviour();
        }

        static void DemoHigherOrderFunctions()
        {
            Linq.DemoFilter();

            Linq.DemoSelect();

            Linq.DemoAll();

            //var badCats = Enumerable.Range(0, 5)
            //    .Select(i => new Cat("Bad cat"));

            //ExceptKeys.Demo(badCats);
        }
    }
}
