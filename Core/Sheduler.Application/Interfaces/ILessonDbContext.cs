using Sheduler.Application.Common.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Interfaces;

public interface ILessonsDbContext : IDbContext<Lesson>
{
    
}