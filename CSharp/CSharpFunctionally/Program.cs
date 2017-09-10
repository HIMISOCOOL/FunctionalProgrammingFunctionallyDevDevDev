using System;
using System.Linq;

namespace CSharpFunctionally
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo1 = new ExceptAndIntersectFunctionally();

            var random = new Random();
            var newCats = Cat.GenerateCats(random.Next(0, 9));

            demo1.AddNewCats(newCats);
        }
    }
}
