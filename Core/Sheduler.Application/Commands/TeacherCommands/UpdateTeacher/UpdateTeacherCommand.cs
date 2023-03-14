using MediatR;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommand : IRequest<Teacher>
{
    public string TeacherName { get; set; }
    public int UserId { get; set; }
    public string NewName { get; set; } = string.Empty;
}