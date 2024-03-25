using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using ToDo.API.Infrastructure.Models.SubTaskModels;
using ToDo.API.Infrastructure.Models.ToDoItemModels;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class ToDoItemPostModelExample : IExamplesProvider<ToDoItemPostModel>
    {
        public ToDoItemPostModel GetExamples()
        {
            return new ToDoItemPostModel
            {
                Title = "დასასრულებელია ToDo Api",
                TargetCompletionDate = DateTime.Now,
                Subtasks = new List<SubtaskRequestModel>
                {
                    new SubtaskRequestModel()
                    {
                              Title = "დასასრულებელია სვაგერის დოკუმენტაცია"
                    },
                    new SubtaskRequestModel()
                    {
                              Title = "დასასრულებელია მაგალითები სვაგერისთვის"
                    }
                }
            };
        }
    }
}
