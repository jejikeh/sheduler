namespace Sheduler.WebApi.Extensions;

public static class ServiceMiddlewareExtension
{
    public static WebApplicationBuilder RegisterServiceMiddlewares(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(ITeacherRepository).Assembly));
        });

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration);
        return builder;
    }
    
    public static WebApplication InitializeServiceContextProvider(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var shedulerDbContext = serviceProvider.GetRequiredService<ShedulerDbContext>();
            DbInitializer.Initialize(shedulerDbContext);
        }
        catch (Exception ex)
        {
            //
        }

        return app;
    }
}