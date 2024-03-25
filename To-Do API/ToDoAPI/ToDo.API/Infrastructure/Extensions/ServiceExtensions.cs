using ToDo.Application.Subtasks;
using ToDo.Application.ToDos;
using ToDo.Application.Users;
using ToDo.Infrastructure.SubTasks;
using ToDo.Infrastructure.ToDos;
using ToDo.Infrastructure.Users;

namespace ToDo.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IToDoService, ToDoService>();
           services.AddScoped<IToDoRepository, ToDoRepository>();

            services.AddScoped<ISubtaskService, SubtaskService>();
            services.AddScoped<ISubtaskRepository, SubTaskRepository>();
        }
    }
}
