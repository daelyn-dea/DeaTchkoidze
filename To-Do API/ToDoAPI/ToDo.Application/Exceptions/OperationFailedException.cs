using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Exceptions
{
    public class OperationFailedException : Exception
    {
        public readonly string Code = "OperationFailed";

        public OperationFailedException(string message = "Can't delete.") : base(message)
        {
        }
    }
}
