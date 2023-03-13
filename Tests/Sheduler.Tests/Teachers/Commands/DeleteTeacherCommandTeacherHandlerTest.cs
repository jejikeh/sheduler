using Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.TeacherRelated;

namespace Sheduler.Tests.Teachers.Commands;

public class DeleteTeacherCommandTeacherHandlerTest : TestCommandTeacherBase
{
    [Fact]
    public async Task DeleteTeacherCommandHandler_FailOnWrongId()
    {
        var handler = new DeleteTeacherCommandHandler(Context);
        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTeacherCommand()
            {
                Id = Guid.NewGuid(),
                UserId = DbContextFactory.UserAId
            },
            CancellationToken.None));
    }
}