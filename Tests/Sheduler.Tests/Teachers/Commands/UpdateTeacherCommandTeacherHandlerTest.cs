using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;
using Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Domain.Models;
using Sheduler.Persistence;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.TeacherRelated;

namespace Sheduler.Tests.Teachers.Commands;

public class UpdateTeacherCommandTeacherHandlerTest : TestCommandTeacherBase
{
    [Fact]
    public async Task UpdateTeacherCommandHandler_Success()
    {
        var handler = new UpdateTeacherCommandHandler(Context);
        var updateTeacherCommand = new UpdateTeacherCommand()
        {
            Id = Guid.Parse("FC986B32-DA05-4F78-A737-DE48356E2F07"),
            UserId = DbContextFactory.UserAId,
            Name = "Andrew"
        };

        await handler.Handle(updateTeacherCommand, CancellationToken.None);
        Assert.NotNull(await Context.Set().SingleOrDefaultAsync(
            teacher => 
                teacher.Id == Guid.Parse("FC986B32-DA05-4F78-A737-DE48356E2F07") &&
                teacher.Name == "Andrew"));
    }
}