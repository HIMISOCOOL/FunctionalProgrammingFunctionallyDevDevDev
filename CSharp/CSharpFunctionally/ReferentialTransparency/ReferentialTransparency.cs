using System;

namespace CSharpFunctionally.ReferentialTransparency
{
    public static class Math
    {
        public static int Add(int left, int right)
        {
            return left + right;
        }

        public static int Subtract(int left, int right)
        {
            return left - right;
        }

        public static int Multiply(int left, int right)
        {
            return left * right;
        }

        // What about this one?
        public static int Divide(int left, int right)
        {
            return left / right;
        }
    }

    public static class ReferentialTransparentExamples
    {
        public static long TicksElapsedFrom(int year)
        {
            DateTime now = DateTime.Now;
            DateTime then = new DateTime(year, 1, 1);

            return (now - then).Ticks;
        }

        public static long TicksElapsedFrom(int year, DateTime now)
        {
            DateTime then = new DateTime(year, 1, 1);

            return (now - then).Ticks;
        }

        public static int F1()
        {
            // Method is Refentially Transparent
            return 0;
        }

        public static int F2()
        {
            // Method is honest
            return new Random().Next(int.MinValue, int.MaxValue);
        }
    }
}
