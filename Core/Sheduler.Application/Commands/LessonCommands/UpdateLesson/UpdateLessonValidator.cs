using FluentValidation;

namespace Sheduler.Application.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonValidator()
    {
        RuleFor(command => command.Title).NotEmpty().MaximumLength(250);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}