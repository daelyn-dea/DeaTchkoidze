using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos.ResponseModel
{
    public class ToDoItemResponseModel
    {
        public int Id {  get; set; } 
        public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public Status Status { get; set; }
        public List<Subtask>? Subtasks { get; set; }
    }
}
