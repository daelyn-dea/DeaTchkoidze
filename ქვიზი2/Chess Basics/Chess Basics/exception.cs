using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Basics
{
    internal class exceptionOfBoard : Exception
    {
        public exceptionOfBoard(string? message) : base(message)
        {
           
        }
    }
}
