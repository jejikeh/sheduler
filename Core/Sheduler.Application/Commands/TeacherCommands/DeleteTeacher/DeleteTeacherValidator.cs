using FluentValidation;
using Sheduler.Application.Commands.LessonCommands.DeleteLesson;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherValidator : AbstractValidator<DeleteTeacherCommand>
{
    public DeleteTeacherValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}