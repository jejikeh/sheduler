using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Tests.Common;

namespace Sheduler.Tests.Teachers.Commands;

public class CreateTeacherCommandHandlerTest : TestCommandBase
{
    [Fact]
    public async Task CreateTeacherCommandHandler_Success()
    {
        var handler = new CreateTeacherCommandHandler(Context);
        var teacherName = "Bazykov";
        var createTeacherCommand = new CreateTeacherCommand()
        {
            Name = teacherName,
            UserId = TeacherContextFactory.UserAId
        };

        var teacherId = await handler.Handle(createTeacherCommand, CancellationToken.None);
        
        Assert.NotNull(await Context.Set(). SingleOrDefaultAsync(teacher => teacher.Id == teacherId && teacher.Name == teacherName && teacher.UserId == TeacherContextFactory.UserAId));
    }
}