using System.Collections.Generic;
using System.Text;

namespace CSharpFunctionally
{
    public class ExceptAndIntersectFunctionally
    {
        public readonly List<Cat> ExistingCats = new List<Cat>();

        public ExceptAndIntersectFunctionally()
        {
            ExistingCats.AddRange(Cat.GenerateCats(18));
        }

        public void AddNewCats(IEnumerable<Cat> cats)
        {
            ExistingCats.AddRange(cats);
        }
    }
}
