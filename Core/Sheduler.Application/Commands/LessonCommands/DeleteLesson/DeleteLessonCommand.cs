using MediatR;

namespace Sheduler.Application.Commands.LessonCommands.DeleteLesson;

public class DeleteLessonCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}