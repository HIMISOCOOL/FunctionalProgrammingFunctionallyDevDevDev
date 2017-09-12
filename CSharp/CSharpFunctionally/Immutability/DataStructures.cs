using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace CSharpFunctionally.Immutability
{
    public class DataStructures
    {
        public ImmutableDictionary<string, string> AsImmutableDictionary(Dictionary<string, string> dictionary)
        {
            var immutable = dictionary.ToImmutableDictionary();

            //immutable["test"] = "somethingElse";
            //immutable.Add("test", "somethingElse");

            return immutable;
        }

        public void AddEntries(ImmutableDictionary<string, string> dictionary)
        {
            var initialCount = dictionary.Add("Some Key", "Some Value");
        }

        public ImmutableStack<int> AsImmutableStack(Stack<int> stack)
        {
            var immutable = ImmutableStack<int>.Empty;

            stack.Push(7);
            immutable.Push(7);

            stack.Push(3);
            immutable.Push(3);

            stack.Push(1);
            immutable.Push(1);

            return immutable;
        }

        public void ImmutableStackCanShareState()
        {
            var immutable = ImmutableStack<int>.Empty;
            var immutable2 = ImmutableStack<int>.Empty;
            bool areSame = immutable == immutable2;

            immutable = immutable.Push(7);
            immutable2 = immutable2.Push(5);
            areSame = immutable == immutable2;

            immutable = immutable.Pop();
            immutable2 = immutable2.Pop();
            areSame = immutable == immutable2;

            var tail = immutable.Push(7);
            var immutable3 = tail.Push(8);
            var immutable4 = tail.Push(9);

            FieldInfo[] fieldsImmutable3 = immutable3.GetType()
                 .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsImmutable4 = immutable4.GetType()
                 .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            bool sameTail = fieldsImmutable3[1] == fieldsImmutable4[1];

            tail.Pop();

            sameTail = fieldsImmutable3[1] == fieldsImmutable4[1];
        }

        public void OddBehaviour()
        {
            var stack = ImmutableStack<NonFunctionalCat>.Empty;

            var stackWithCat = stack.Push(new NonFunctionalCat("Alfred"));

            var cat = stackWithCat.Peek();
            Console.WriteLine(cat.Name);

            cat.Name = "Bethany";

            stackWithCat.Pop(out NonFunctionalCat cat1);
            Console.WriteLine(cat1.Name);
        }
    }
}
