using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    public static class IntExtension
    {
        public static string EvenOrOdd(this int input)
        {
            string result = "Odd";
            if(input % 2 == 0)
            {
                result = "Even";
            }
            return result;           
        }
        public static int AbsoluteValue(this int input)
        {
            if (input < 0)
            {
                return input *-1;
            }
            return input;
        }
        public static int RoundNearestMultiple(this int input)
        {
            for(int i = input+1; i < int.MaxValue; i++)
            {
                if(i % input == 0)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
