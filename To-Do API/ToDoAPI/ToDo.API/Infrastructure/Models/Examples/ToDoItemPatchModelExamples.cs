using Swashbuckle.AspNetCore.Filters;
using ToDo.API.Infrastructure.Models.ToDoItemModels;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class ToDoItemPatchModelExamples : IMultipleExamplesProvider<ToDoItemPatchModel>
    {
        public IEnumerable<SwaggerExample<ToDoItemPatchModel>> GetExamples()
        {

            yield return SwaggerExample.Create("Order 1", new ToDoItemPatchModel
            {
                Title = "დასასრულებელია ToDo Api"
            });
            yield return SwaggerExample.Create("Order 1", new ToDoItemPatchModel
            {
                Title = "დასასრულებელია ToDo Api",
                TargetCompletionDate = DateTime.Now
            });
            yield return SwaggerExample.Create("Order 1", new ToDoItemPatchModel
            {
                TargetCompletionDate = DateTime.Now
            });
        }
    }
}