using PizzaProject.API.Infrastructure.Extensions;
using PizzaProject.API.Infrastructure.Mappings;
using PizzaProject.API.Middlewares;
using PizzaProject.Persistence;
using FluentValidation.AspNetCore;
using Serilog;
using FluentValidation;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pizza API",
        Description = "Api for managment Pizza service",
        Contact = new OpenApiContact
        {
            Name = "daelyn",
            Url = new Uri("https://dominospizza.com/contact")
        },
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
    options.ExampleFilters();
});

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

// Add services before building the application
builder.Services.AddServices();


// Configure options during service registration
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.RegisterMaps();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddlware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza API v1");
    });
 };

app.UseSerilogRequestLogging();
// Continue with other configurations...
app.UseRequestCulture();

app.MapControllers();

app.Run();
