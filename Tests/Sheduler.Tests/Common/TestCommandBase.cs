using Sheduler.Persistence;

namespace Sheduler.Tests.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly TeachersDbContext Context;

    public TestCommandBase()
    {
        Context = TeacherContextFactory.Create();
    }
    
    public void Dispose()
    {
        TeacherContextFactory.Destroy(Context);
    }
}