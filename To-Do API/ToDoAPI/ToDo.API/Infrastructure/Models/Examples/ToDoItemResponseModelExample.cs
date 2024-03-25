using Swashbuckle.AspNetCore.Filters;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Domain.Subtasks;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class ToDoItemResponseModelExample : IExamplesProvider<ToDoItemResponseModel>
    {
        public ToDoItemResponseModel GetExamples()
        {
            return new ToDoItemResponseModel
            {
                Title = "დასასრულებელია ToDo Api",
                TargetCompletionDate = DateTime.Now,
                Status = Domain.ToDos.Status.Done,
                Subtasks = new List<Subtask>
                {
                    new Subtask()
                    {
                              Title = "დასასრულებელია სვაგერის დოკუმენტაცია"
                    },
                    new Subtask()
                    {
                              Title = "დასასრულებელია მაგალითები სვაგერისთვის"
                    }
                }
            };
        }
    }
}