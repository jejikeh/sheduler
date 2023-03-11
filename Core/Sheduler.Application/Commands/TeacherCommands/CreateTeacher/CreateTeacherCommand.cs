using MediatR;

namespace Sheduler.Application.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}