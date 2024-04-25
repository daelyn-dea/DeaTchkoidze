using Forum.API.Infrastructure.StartupConfiguration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .CreateLogger();
try
{
    Log.Information("Configuring Services");
    builder.ConfigureServices();

    var app = builder.Build();
    Log.Information("Configuring Middleware");
    app.ConfigureMiddleware();

    Log.Information("Starting App");
    app.Run();
    Log.Information("Ending App");
}
catch(Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

