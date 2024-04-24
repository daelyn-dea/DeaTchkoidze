using System.ComponentModel.DataAnnotations;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.SubTaskModels;
using ToDo.Application.Subtasks.RequestModel;

namespace ToDo.API.Infrastructure.Models.ToDoItemModels
{
    public class ToDoItemPostModel
    {
        public string Title { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Target completion date must be a valid date")]
        public DateTime? TargetCompletionDate { get; set; }
        public List<SubtaskRequestModel> Subtasks { get; set; }
    }
}
