using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Interfaces;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Core.Primitives.Entities;
using Sheduler.Domain.Core.Utils;
using Sheduler.Domain.Models;
using Sheduler.Persistence.Configurations;

namespace Sheduler.Persistence;

public class TeachersDbContext : DbContext, ITeachersDbContext
{
    public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options)
    {
    }

    public DbSet<Teacher> Set()
    {
        return base.Set<Teacher>();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeacherConfiguration());
        base.OnModelCreating(builder);
    }
    
    public async Task<Teacher?> FindTeacherAsync(string name)
    {
        Ensure.NotNull(name, string.Empty, nameof(name));
        return await Set().FirstOrDefaultAsync(teacher => teacher.Name.Equals(name));
    }
}