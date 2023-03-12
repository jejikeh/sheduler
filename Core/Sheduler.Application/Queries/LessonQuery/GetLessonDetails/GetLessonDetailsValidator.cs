using FluentValidation;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

public class GetLessonsDetailsValidator : AbstractValidator<GetLessonDetailsQuery>
{
    public GetLessonsDetailsValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}