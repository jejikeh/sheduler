using Microsoft.EntityFrameworkCore;

namespace Sheduler.Application.Common.Interfaces;

public interface IDbContext<T> where T : class
{
    public DbSet<T> Set();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}