using FluentValidation;
using PizzaProject.API.Models.Examples.AddressExamples;
using PizzaProject.API.Models.Examples.OrderExample;
using PizzaProject.API.Models.Examples.PizzaExamlpes;
using PizzaProject.API.Models.Examples.UserExamples;
using PizzaProject.API.Models.Requests.AddressRequests;
using PizzaProject.API.Models.Requests.OrderRequest;
using PizzaProject.API.Models.Requests.PizzaRequests;
using PizzaProject.API.Models.Requests.UserRequests;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Orders;
using PizzaProject.Application.Pizzas;
using PizzaProject.Application.RankHistories;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Users;
using PizzaProject.Application.Validators;
using PizzaProject.Infrastructure.Addresses;
using PizzaProject.Infrastructure.Orders;
using PizzaProject.Infrastructure.Pizzas;
using PizzaProject.Infrastructure.RankHistories;
using PizzaProject.Infrastructure.Users;
using Swashbuckle.AspNetCore.Filters;


namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IExamplesProvider<PizzaCreateModel>, PizzaCreateModelExample>();


            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddTransient<IExamplesProvider<AddressCreateModel>, AddressCreateModelExample>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IExamplesProvider<UserCreateModel>, UserCreateModelExample>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IExamplesProvider<OrderCreateModel>, OrderCreateExample>();

            services.AddScoped<IRankHistoryService, RankHistoryService>();
            services.AddScoped<IRankHistoryRepository, RankHistoryRepository>();


            services.AddScoped<IValidatorService, ValidatorService>();
        }
    }
}
