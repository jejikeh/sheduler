using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Application.Interfaces;

namespace Sheduler.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<TeachersDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("TeachersDbConnection")));
        serviceCollection.AddScoped<ITeachersDbContext>(provider => provider.GetService<TeachersDbContext>() ?? throw new InvalidOperationException());
        
        serviceCollection.AddDbContext<LessonsDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("LessonsDbConnection")));
        serviceCollection.AddScoped<ILessonsDbContext>(provider => provider.GetService<LessonsDbContext>() ?? throw new InvalidOperationException());
        
        return serviceCollection;
    }
}