using Forum.Application.Topics;
using Forum.Application.Users;
using Forum.Infrastructure.BaseRepository;
using Forum.Infrastructure.Topics;
using Forum.Infrastructure.Users;
using Forum.Persistence.Context;
using Forum.Worker.BackgroundWorkers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

try
{
    await CreateHostBuilder(args).Build().RunAsync().ConfigureAwait(false);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Worker terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .UseWindowsService()
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<ForumContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Transient);
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITopicRepository, TopicRepository>();
            services.AddHostedService<TopicArchiveWorker>();
            services.AddHostedService<BlockRemovalWorker>();
        });
