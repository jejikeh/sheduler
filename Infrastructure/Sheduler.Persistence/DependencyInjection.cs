using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Application.Interfaces;
using Sheduler.Persistence.Repositories;

namespace Sheduler.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ShedulerDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("ShedulerDbConnection")));

        serviceCollection.AddScoped<ITeacherRepository, TeacherRepository>();
        return serviceCollection;
    }
}