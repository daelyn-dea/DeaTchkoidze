using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Exceptions
{
    public class ToDoItemNotFoundException : Exception
    {
        public readonly string Code = "ToDorNotFound";

        public ToDoItemNotFoundException(string message = "ToDo not found") : base(message)
        {
        }
    }
}
