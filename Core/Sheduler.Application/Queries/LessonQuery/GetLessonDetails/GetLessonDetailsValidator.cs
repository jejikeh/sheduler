using FluentValidation;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

public class GetLessonDetailsValidator : AbstractValidator<GetLessonDetailsQuery>
{
    public GetLessonDetailsValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}