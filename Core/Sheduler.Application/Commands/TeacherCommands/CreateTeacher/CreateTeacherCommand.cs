using MediatR;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.Teachers;

public class CreateTeacherCommand : IRequest<Teacher>
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}