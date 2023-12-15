using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    internal static class MATH
    {
        public static int Max(int num1, int num2, out ENUMS.Status status)
        {
            if(num1 == num2)
            {
                status = ENUMS.Status.Equals;
            }
            else
            {
                status = ENUMS.Status.Success;
            }
            if(status == ENUMS.Status.Success)
            {
                if(num1 > num2)
                {
                    return num1;
                }
                else
                {
                    return num2;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int Min(int num1, int num2, out ENUMS.Status status)
        {
            if (num1 == num2)
            {
                status = ENUMS.Status.Equals;
            }
            else
            {
                status = ENUMS.Status.Success;
            }
            if (status == ENUMS.Status.Success)
            {
                if (num1 > num2)
                {
                    return num2;
                }
                else
                {
                    return num1;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int Pow(int num, int pow, out ENUMS.Status status)
        {
            if (pow >= 0)
            {
                status = ENUMS.Status.Success;
            }
            else
            {
                status = ENUMS.Status.PowMustBePositiveOrZero;
            }
            if (status == ENUMS.Status.Success)
            {
                if (pow == 0)
                    return 1;
                if (pow >= 1)
                {
                    int saveNum = num;
                    for (int i = 1; i < pow; i++)
                    {
                        num *= saveNum;
                     
                    }
                    return num;
                }
            }
                return 0;
        }
    }
}
