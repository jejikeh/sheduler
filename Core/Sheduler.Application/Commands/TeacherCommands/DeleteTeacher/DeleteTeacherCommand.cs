using MediatR;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}