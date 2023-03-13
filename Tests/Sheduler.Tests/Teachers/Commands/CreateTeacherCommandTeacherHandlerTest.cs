using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Domain.Models;
using Sheduler.Persistence;
using Sheduler.Tests.Common;

namespace Sheduler.Tests.Teachers.Commands;

public class CreateTeacherCommandHandlerTest : TestCommandBase<TeachersDbContext, Teacher>
{
    [Fact]
    public async Task CreateTeacherCommandHandler_Success()
    {
        var handler = new CreateTeacherCommandHandler(Context);
        var teacherName = "Bazykov";
        var createTeacherCommand = new CreateTeacherCommand()
        {
            Name = teacherName,
            UserId = DbContextFactory<TeachersDbContext, Teacher>.UserAId
        };

        var teacherId = await handler.Handle(createTeacherCommand, CancellationToken.None);
        
        Assert.NotNull(await Context.Set(). SingleOrDefaultAsync(teacher => teacher.Id == teacherId && teacher.Name == teacherName && teacher.UserId == DbContextFactory<TeachersDbContext, Teacher>.UserAId));
    }

    public CreateTeacherCommandHandlerTest(Func<DbContextOptions<TeachersDbContext>, TeachersDbContext> createContext, params Teacher[] entities) : base(createContext, entities)
    {
    }
}