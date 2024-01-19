using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class MathOperations
    {
        public static decimal Add(decimal a, decimal b)
        {
              return a + b;
        }
        public static decimal Subtract(decimal a, decimal b)
        { 
            return a - b; 
        }
        public static decimal Multiply(decimal a, decimal b)
        {
            return (a * b);
        }
        public static decimal Divide(decimal a, decimal b)
        {
            return (a / b);
        }
    }
}
