using MediatR;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

public class GetLessonDetailsQuery : IRequest<LessonDetailsVm>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}