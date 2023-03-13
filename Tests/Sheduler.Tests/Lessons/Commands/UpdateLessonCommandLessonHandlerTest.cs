using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Commands.LessonCommands.UpdateLesson;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Domain.Models.Types;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.LessonRelated;

namespace Sheduler.Tests.Lessons.Commands;

public class UpdateLessonCommandLessonHandlerTest : TestCommandLessonBase
{
    [Fact]
    public async Task UpdateLessonCommandHandler_Failure()
    {
        var handler = new UpdateLessonsCommandHandler(LessonContext, TeacherContext);
        var lessonName = "Poetry";
        var updateLessonCommand = new UpdateLessonCommand()
        {
            Id = Guid.Parse("E1091B9F-9A81-41C1-9889-5882E191E6BA"),
            UserId = DbContextFactory.UserAId,
            DateTime = DateTime.Today,
            LessonType = LessonType.Lecture,
            TeacherName = "Lebedev",
            Title = lessonName
        };
        
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(updateLessonCommand, CancellationToken.None));
    }
    
    [Fact]
    public async Task UpdateLessonCommandHandler_Success()
    {
        var handler = new UpdateLessonsCommandHandler(LessonContext, TeacherContext);
        var lessonName = "Poetry";
        var updateLessonCommand = new UpdateLessonCommand()
        {
            Id = Guid.Parse("E1091B9F-9A81-41C1-9889-5882E191E6BA"),
            UserId = DbContextFactory.UserAId,
            DateTime = DateTime.Today,
            LessonType = LessonType.Lecture,
            TeacherName = "Petrov",
            Title = lessonName
        };

        await handler.Handle(updateLessonCommand, CancellationToken.None);
        var lesson = await LessonContext.Set().SingleOrDefaultAsync(
            lesson => lesson.Title == "Poetry");

        Assert.Contains("Petrov", lesson.Teacher.Name);
    }
    
    [Fact]
    public async Task UpdateLessonCommandHandlerDoNotChangeFields_Success()
    {
        var handler = new UpdateLessonsCommandHandler(LessonContext, TeacherContext);
        var lessonName = "Poetry";
        var updateLessonCommand = new UpdateLessonCommand()
        {
            Id = Guid.Parse("E1091B9F-9A81-41C1-9889-5882E191E6BA"),
            UserId = DbContextFactory.UserAId,
            DateTime = DateTime.Today,
            LessonType = LessonType.Lecture,
            Title = lessonName
        };

        await handler.Handle(updateLessonCommand, CancellationToken.None);
        var lesson = await LessonContext.Set().SingleOrDefaultAsync(
            lesson => lesson.Title == "Poetry");

        Assert.Contains("Metrov", lesson.Teacher.Name);
        Assert.Contains("Poetry", lesson.Title);
    }
}