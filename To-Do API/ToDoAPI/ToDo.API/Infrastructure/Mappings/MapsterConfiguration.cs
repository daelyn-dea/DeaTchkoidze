using Mapster;
using ToDo.Application.Users.RequestModels;
using ToDo.Application.Users.ResponseModels;
using ToDo.Domain.Users;

namespace ToDo.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<UserRequestPostModel, User>
                 .NewConfig()
                 .Map(dest => dest.PasswordHash, src => src.Password)
                 .TwoWays();
        }
    }
}
