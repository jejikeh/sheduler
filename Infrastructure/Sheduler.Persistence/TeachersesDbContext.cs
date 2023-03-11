using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Interfaces;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Core.Primitives.Entities;
using Sheduler.Domain.Core.Utils;
using Sheduler.Domain.Models;
using Sheduler.Persistence.Configurations;

namespace Sheduler.Persistence;

public class TeachersDbContext : DbContext, ITeacherDbContext
{
    public DbSet<Teacher?> Set()
    {
        return base.Set<Teacher>();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeacherConfiguration());
        base.OnModelCreating(builder);
    }
    
    public async Task<Teacher?> FindTeacherAsync(Guid id)
    {
        Ensure.GreaterThan(id, Guid.Empty, "The id must be greater than zero", nameof(id));

        return await Set().FindAsync(id);
    }
}