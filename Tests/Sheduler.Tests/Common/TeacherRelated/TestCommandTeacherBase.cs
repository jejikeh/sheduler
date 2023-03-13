using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common;

public abstract class TestCommandTeacherBase
{
    protected readonly TeachersDbContext Context;

    public TestCommandTeacherBase()
    {
        Context = DbContextFactory<TeachersDbContext, Teacher>.Create(
            options => new TeachersDbContext(options),
            TestDataCollection.Teachers);
    }
    
    public void Dispose()
    {
        DbContextFactory<TeachersDbContext, Teacher>.Destroy(Context);
    }
}