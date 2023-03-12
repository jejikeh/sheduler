using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;
using Sheduler.Persistence.Configurations;

namespace Sheduler.Persistence;

public class LessonsDbContext : DbContext, ILessonsDbContext
{
    public LessonsDbContext(DbContextOptions<LessonsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Lesson> Set()
    {
        return base.Set<Lesson>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new LessonConfiguration());
        base.OnModelCreating(builder);
    }
}