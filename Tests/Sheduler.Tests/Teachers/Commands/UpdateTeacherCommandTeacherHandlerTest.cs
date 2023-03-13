using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Domain.Models;
using Sheduler.Persistence;
using Sheduler.Tests.Common;

namespace Sheduler.Tests.Teachers.Commands;

public class UpdateTeacherCommandHandlerTest : TestCommandBase<TeachersDbContext, Teacher>
{
    [Fact]
    public async Task UpdateTeacherCommandHandler_Success()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        var deleteTeacherCommand = new DeleteTeacherCommand()
        {
            Id = DbContextFactory<TeachersDbContext, Teacher>.ForDelete,
            UserId = DbContextFactory<TeachersDbContext, Teacher>.UserAId
        };

        await handler.Handle(deleteTeacherCommand, CancellationToken.None);
        Assert.Null(await Context.Set(). SingleOrDefaultAsync(teacher => teacher.Id == DbContextFactory<TeachersDbContext, Teacher>.ForDelete));
    }
    
    [Fact]
    public async Task DeleteTeacherCommandHandler_FailOnWrongId()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTeacherCommand()
            {
                Id = Guid.NewGuid(),
                UserId = DbContextFactory<TeachersDbContext, Teacher>.UserAId
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
                UserId = DbContextFactory<TeachersDbContext, Teacher>.UserAId
            },
            CancellationToken.None));
    }

    public UpdateTeacherCommandHandlerTest(Func<DbContextOptions<TeachersDbContext>, TeachersDbContext> createContext, params Teacher[] entities) : base(createContext, entities)
    {
    }
}