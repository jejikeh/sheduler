using FluentValidation;

namespace Sheduler.Application.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
    }
}