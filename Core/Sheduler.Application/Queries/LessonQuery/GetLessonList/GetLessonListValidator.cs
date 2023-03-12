using FluentValidation;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonList;

public class GetLessonListValidator : AbstractValidator<GetLessonListQuery>
{
    public GetLessonListValidator()
    {
        RuleFor(query => query.UserId).NotEqual(Guid.Empty);
    }
}