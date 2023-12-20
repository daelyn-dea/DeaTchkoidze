using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public static class Calculate
    {
        public static void CalculateSumAndDifference(int num1, int num2, out int sum, out int difference)
        {
            sum = num1 + num2;
            difference = num1 - num2;
        }
        public static Tuple<int, int> CalculateSumAndDifferenceByTuple(int num1, int num2)
        {
            int sum = num1 + num2;
            int difference = num1 - num2;
            return Tuple.Create(sum, difference);
        }

    }
}