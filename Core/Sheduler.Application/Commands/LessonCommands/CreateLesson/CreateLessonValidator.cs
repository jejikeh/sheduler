using FluentValidation;

namespace Sheduler.Application.Commands.LessonCommands.CreateLesson;

public class CreateLessonValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonValidator()
    {
        RuleFor(command => command.Title).NotEmpty().MaximumLength(250);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}