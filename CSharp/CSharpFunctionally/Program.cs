using CSharpFunctionally.Immutability;
using System;
using System.Linq;

namespace CSharpFunctionally
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            DemoImmutability();
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

        static void Demo1()
        {
            var demo1 = new ExceptAndIntersectFunctionally();

            var random = new Random();
            var newCats = Cat.GenerateCats(random.Next(0, 9));

            demo1.AddNewCats(newCats);
        }
    }
}
