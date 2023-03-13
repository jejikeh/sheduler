using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common.LessonRelated;

public class TestCommandLessonBase
{
    protected readonly LessonsDbContext LessonContext;
    protected readonly TeachersDbContext TeacherContext;

    public TestCommandLessonBase()
    {
        LessonContext = DbContextFactory.Create<LessonsDbContext, Lesson>(
            options => new LessonsDbContext(options),
            TestDataCollection.Lessons);
        
        TeacherContext = DbContextFactory.Create<TeachersDbContext, Teacher>(
            options => new TeachersDbContext(options),
            TestDataCollection.Teachers);
    }
    
    public void Dispose()
    {
        DbContextFactory.Destroy(LessonContext);
    }
}