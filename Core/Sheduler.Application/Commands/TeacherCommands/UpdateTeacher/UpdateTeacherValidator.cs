using FluentValidation;

namespace Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
    }
}