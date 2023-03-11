using MediatR;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Application.Commands.LessonCommands.CreateLesson;

public class CreateLessonCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TeacherName { get; set; } = string.Empty;
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }
}