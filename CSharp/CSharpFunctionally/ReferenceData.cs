using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionally
{
    public class ReferenceData
    {
        public static readonly List<string> Guids = Enumerable.Range(0, 300)
            .Select(i => Guid.NewGuid().ToString())
            .ToList();
    }
}
