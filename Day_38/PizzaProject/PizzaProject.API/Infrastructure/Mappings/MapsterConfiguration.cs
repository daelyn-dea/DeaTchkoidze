using Mapster;
using PizzaProject.API.Models.Responses.OrderResponses;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Orders;
using PizzaProject.Application.Pizzas;
using PizzaProject.Application.Users;
using PizzaProject.Domain.Entity;
using System;

namespace PizzaProject.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<PizzaRequestModel, Pizza>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<AddressRequestModel, Address>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<UserRequestModel, User>
            .NewConfig()
            .TwoWays();


            TypeAdapterConfig<OrderRequestModel, Order>
            .NewConfig()
            .TwoWays();


            TypeAdapterConfig<OrderDtoModel, OrderResponseModel>
            .NewConfig()
            .TwoWays();


        }
    }
}
