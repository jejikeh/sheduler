using MediatR;
using Sheduler.Domain.Models;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Application.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string TeacherName { get; set; }
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }
}