using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Tests.Common;

namespace Sheduler.Tests.Teachers.Commands;

public class UpdateTeacherCommandHandlerTest : TestCommandBase
{
    [Fact]
    public async Task UpdateTeacherCommandHandler_Success()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        var deleteTeacherCommand = new DeleteTeacherCommand()
        {
            Id = TeacherContextFactory.TeacherForDelete,
            UserId = TeacherContextFactory.UserAId
        };

        await handler.Handle(deleteTeacherCommand, CancellationToken.None);
        Assert.Null(await Context.Set(). SingleOrDefaultAsync(teacher => teacher.Id == TeacherContextFactory.TeacherForDelete));
    }
    
    [Fact]
    public async Task DeleteTeacherCommandHandler_FailOnWrongId()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTeacherCommand()
            {
                Id = Guid.NewGuid(),
                UserId = TeacherContextFactory.UserAId
            },
            CancellationToken.None));
    }
    
    [Fact]
    public async Task DeleteTeacherCommandHandler_FailOnWrongUserId()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTeacherCommand()
            {
                Id = Guid.NewGuid(),
                UserId = TeacherContextFactory.UserAId
            },
            CancellationToken.None));
    }
}