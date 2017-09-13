using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFunctionally.Purity
{
    public class Purity
    {
        public int Max(int a, int b)
        {
            return a > b
                ? a
                : b;
        }

        public int Max(int a, int b, ILogger logger)
        {
            int greater = a > b
                ? a
                : b;

            if (a > b)
            {
                logger.Log($"{a} is greater than {b}");
            }
            else
            {
                logger.Log($"{b} is greater than {a}");
            }

            return greater;
        }

        public int MaxWithLog(int a, int b, ILogger logger)
        {
            int greater = Max(a, b);

            if (a == greater)
            {
                logger.Log($"{a} is greater than {b}");
            }
            else
            {
                logger.Log($"{b} is greater than {a}");
            }

            return greater;
        }
    }
}
