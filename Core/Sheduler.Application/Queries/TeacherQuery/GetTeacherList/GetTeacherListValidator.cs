using FluentValidation;
using Sheduler.Application.Queries.LessonQuery.GetLessonList;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

public class GetTeacherListValidator : AbstractValidator<GetTeacherListQuery>
{
    public GetTeacherListValidator()
    {
        RuleFor(query => query.UserId).NotEqual(Guid.Empty);
    }
}