using FluentValidation;
using Sheduler.Application.Queries.LessonQuery.GetLessonList;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

public class GetLessonListValidator : AbstractValidator<GetLessonListQuery>
{
    public GetLessonListValidator()
    {
        RuleFor(query => query.UserId).NotEqual(Guid.Empty);
    }
}