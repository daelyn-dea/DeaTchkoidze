using Swashbuckle.AspNetCore.Filters;
using ToDo.API.Infrastructure.Models.SubTaskModels;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class SubtaskRequestModelExample : IExamplesProvider<SubtaskRequestModel>
    {
        public SubtaskRequestModel GetExamples()
        {
            return new SubtaskRequestModel
            {
                    Title = "დასასრულებელია სვაგერის დოკუმენტაცია",
            };
        }
    }
}
