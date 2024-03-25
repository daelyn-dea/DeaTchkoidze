using Swashbuckle.AspNetCore.Filters;
using ToDo.Application.ToDos.ResponseModel;
using ToDo.Domain.Subtasks;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class ToDoItemResponseModelListExample : IMultipleExamplesProvider<List<ToDoItemResponseModel>>
    {
        public IEnumerable<SwaggerExample<List<ToDoItemResponseModel>>> GetExamples()
        {
            yield return SwaggerExample.Create("List of Addresses", new List<ToDoItemResponseModel>
            {
                 new ToDoItemResponseModel
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
            },
             new ToDoItemResponseModel
            {
                Title = "დასასრულებელია ToDo Api მეთქი!",
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
                              Title = "დასასრულებელია xml კომენტარების ამბავი"
                    }
                }
            }
            });
        }
    }
}