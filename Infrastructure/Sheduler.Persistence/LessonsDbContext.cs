using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Core.Primitives.Entities;
using Sheduler.Persistence.Configurations;

namespace Sheduler.Persistence;

public class TablesDbContext : DbContext, IDbContext<EntityGuid>
{
    public DbSet<EntityGuid> Set()
    {
        return base.Set<EntityGuid>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new LessonConfiguration());
        base.OnModelCreating(builder);
    }
}