using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Exceptions
{
    public class SubTaskNotFoundException : Exception
    {
        public readonly string Code = "SubTaskNotFound";

           public SubTaskNotFoundException(string message = "Sub Task Not Found.") : base(message)
         {
         }
    }
}
