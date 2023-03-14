using Microsoft.EntityFrameworkCore;
using Sheduler.Domain.Models;
using Sheduler.Persistence.Configuration;

namespace Sheduler.Persistence;

public class ShedulerDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }

    public ShedulerDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeacherConfiguration());
        base.OnModelCreating(builder);
    }
}