using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Subtasks.RequestModel;
using ToDo.Domain.Subtasks;

namespace ToDo.Application.ToDos.ToDoItemRequestModel
{
    public class ToDoItemRequestPostModel
    {
        public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public List<SubtaskRequestPostModel> Subtasks { get; set; }
        public int OwnerId { get; set; }
    }
}
