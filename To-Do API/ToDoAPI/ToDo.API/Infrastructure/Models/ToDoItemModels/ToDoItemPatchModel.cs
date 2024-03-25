namespace ToDo.API.Infrastructure.Models.ToDoItemModels
{
    public class ToDoItemPatchModel
    {
        public string? Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
    }
}
