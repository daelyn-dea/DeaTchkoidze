using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class OutOfRangeException : System.Exception
    {
        public OutOfRangeException(string? message) : base(message)
        {
        }
    }

    internal class OperationException : System.Exception
    {
        public OperationException(string? message) : base(message)
        {
        }
    }
}
