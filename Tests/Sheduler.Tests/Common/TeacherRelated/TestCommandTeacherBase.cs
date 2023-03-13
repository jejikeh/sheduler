using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common.TeacherRelated;

public abstract class TestCommandTeacherBase
{
    protected readonly TeachersDbContext Context;

    public TestCommandTeacherBase()
    {
        Context = DbContextFactory.Create<TeachersDbContext, Teacher>(
            options => new TeachersDbContext(options),
            TestDataCollection.Teachers);
    }
    
    public void Dispose()
    {
        DbContextFactory.Destroy(Context);
    }
}