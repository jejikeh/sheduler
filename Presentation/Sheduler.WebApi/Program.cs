using Sheduler.Persistence;

namespace Sheduler.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var teachersDbContext = serviceProvider.GetRequiredService<TeachersDbContext>();
            var lessonsDbContext = serviceProvider.GetRequiredService<LessonsDbContext>();
            DbInitializer.Initialize(teachersDbContext);
            DbInitializer.Initialize(lessonsDbContext);
        }
        catch (Exception ex)
        {
            // 
        }
        
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}