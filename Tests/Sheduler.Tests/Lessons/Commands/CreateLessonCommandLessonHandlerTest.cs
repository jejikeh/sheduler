using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sheduler.Application.Commands.LessonCommands.CreateLesson;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Domain.Models.Types;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.LessonRelated;

namespace Sheduler.Tests.Lessons.Commands;

public class CreateLessonCommandLessonHandlerTest : TestCommandLessonBase
{
    [Fact]
    public async Task CreateLessonCommandHandler_Success()
    {
        var handler = new CreateLessonCommandHandler(LessonContext, TeacherContext);
        var lessonName = "Physics";
        var createLessonCommand = new CreateLessonCommand()
        {
            UserId = DbContextFactory.UserAId,
            DateTime = DateTime.Today,
            LessonType = LessonType.Practice,
            TeacherName = "Ivanov",
            Title = lessonName
        };

        var teacherId = await handler.Handle(createLessonCommand, CancellationToken.None);
        
        Assert.NotNull(await LessonContext.Set().SingleOrDefaultAsync(
            lesson => lesson.Id == teacherId && lesson.Title == lessonName && lesson.UserId == DbContextFactory.UserAId));
    }
}