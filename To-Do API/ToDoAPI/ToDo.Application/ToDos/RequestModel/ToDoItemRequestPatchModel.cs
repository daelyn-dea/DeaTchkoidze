using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.ToDos.RequestModel
{
    public class ToDoItemRequestPatchModel
    {
        public int id {  get; set; }
        public string? Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int OwnerId { get; set; }
    }
}
