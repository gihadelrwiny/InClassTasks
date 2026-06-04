using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class IntExtensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
      public static bool IsOdd(this int number) {
            return number % 2 != 0;
        }
        public static int Clamp(this int number, int min, int max)
        {
            if (number < min) return min;
            if (number > max) return max;
            return number;
        }
    }
}
