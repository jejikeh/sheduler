using Microsoft.EntityFrameworkCore;

namespace Sheduler.Persistence;

public static class DbInitializer
{
    public static void Initialize<T>(T context) where T : DbContext
    {
        context.Database.EnsureCreated();
    }
}