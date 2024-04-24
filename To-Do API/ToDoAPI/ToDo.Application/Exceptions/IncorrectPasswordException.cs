using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public readonly string Code = "IncorrectPassword";

        public IncorrectPasswordException(string message = "Incorrect password.") : base(message)
        {
        }
    }
}
