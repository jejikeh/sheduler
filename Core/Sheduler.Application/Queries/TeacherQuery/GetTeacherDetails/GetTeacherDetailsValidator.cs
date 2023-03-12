using FluentValidation;
using Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherDetails;

public class GetTeacherDetailsValidator : AbstractValidator<GetTeacherDetailsQuery>
{
    public GetTeacherDetailsValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}