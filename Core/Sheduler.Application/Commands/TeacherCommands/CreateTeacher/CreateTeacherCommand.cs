using MediatR;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommand : IRequest<Teacher>
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}