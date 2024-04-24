using Swashbuckle.AspNetCore.Filters;
using ToDo.API.Infrastructure.Models.SubTaskModels;
using ToDo.Application.Users.RequestModels;

namespace ToDo.API.Infrastructure.Models.Examples
{
    public class UserRequestPostModelExample : IExamplesProvider<UserRequestPostModel>
    {
        public UserRequestPostModel GetExamples()
        {
            return new UserRequestPostModel
            {
                Username = "Username",
                Password = "Password"
            };
        }
    }
}
