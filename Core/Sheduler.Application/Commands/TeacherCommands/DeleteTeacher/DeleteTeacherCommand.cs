using MediatR;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}