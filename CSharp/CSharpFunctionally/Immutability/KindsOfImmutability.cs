using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFunctionally.Immutability
{
    public class KindsOfImmutability
    {
        public const int SomeValue = 7;
        public readonly int[] SomeValues = new int[42];
        public IReadOnlyCollection<int> SomeReadOnlyValues = new int[42];

        public void Mutate()
        {
            //SomeValue = 8;

            //SomeValues = new int[45];

            //SomeValues[4] = 42;

            //SomeReadOnlyValues[1] = 7;
            //SomeReadOnlyValues = new int[900];
            //((int[])SomeReadOnlyValues)[1] = 7;

        }
    }
}
