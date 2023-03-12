using FluentValidation;

namespace Sheduler.Application.Commands.LessonCommands.DeleteLesson;

public class DeleteLessonValidator : AbstractValidator<DeleteLessonCommand>
{
    public DeleteLessonValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}