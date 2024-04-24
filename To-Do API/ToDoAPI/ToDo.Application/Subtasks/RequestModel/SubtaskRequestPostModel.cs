using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.ToDos;

namespace ToDo.Application.Subtasks.RequestModel
{
    public class SubtaskRequestPostModel
    {
        public string Title { get; set; }
        public int ToDoItemId { get; set; }
    }
}
