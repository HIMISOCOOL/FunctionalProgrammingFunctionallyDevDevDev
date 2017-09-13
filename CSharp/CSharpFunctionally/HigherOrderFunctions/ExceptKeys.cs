using CSharpFunctionally.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFunctionally
{
    public class ExceptKeys
    {
        public static readonly List<Cat> ExistingCats = new List<Cat>();

        public static void Demo(IEnumerable<Cat> cats)
        {
            ExistingCats.AddRange(cats);

            ExistingCats.AddRange(Cat.GenerateCats(18));

            var badCats = ExistingCats
                .Where(c => c.Name == "Bad cat")
                .ToList();

            var theBadCats = ExistingCats
                .ExceptKeys(ReferenceData.Guids, c => c.Id.ToString())
                .ToList();
        }
    }
}
