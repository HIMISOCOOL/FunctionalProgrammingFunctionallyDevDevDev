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
            DemoImmutability();
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



            //var dataStructures = new DataStructures();

            //dataStructures.ImmutableStackCanShareState();

            //dataStructures.OddBehaviour();
        }

        static void DemoHigherOrderFunctions()
        {
            Linq.DemoFilter();

            Linq.DemoAllAndAny();

            Linq.DemoSelect();

            Linq.DemoSelectMany();

            Linq.DemoAggregate();

            Linq.DemoOrderBy();

            Linq.DemoExceptIntersect();
        }
    }
}
