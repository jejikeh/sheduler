using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Interfaces;

namespace Sheduler.Tests.Common;

public class DbContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
   
    public static TContext Create<TContext, TEntity>(Func<DbContextOptions<TContext>,TContext> createContext, params TEntity[] entities) where TContext : DbContext, IDbContext<TEntity> where TEntity : class
    {
        var options = new DbContextOptionsBuilder<TContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = createContext.Invoke(options);
        context.Database.EnsureCreated();

        context.Set().AddRange(entities);
        context.SaveChanges();
        return context;
    }

    public static void Destroy<TContext>(TContext context) where TContext : DbContext
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}