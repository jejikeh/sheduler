using MediatR;

namespace Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
}