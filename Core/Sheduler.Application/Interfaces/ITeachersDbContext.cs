using Sheduler.Application.Common.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Interfaces;

public interface ITeachersDbContext : IDbContext<Teacher>
{
    public Task<Teacher?> FindTeacherAsync(string name);
}