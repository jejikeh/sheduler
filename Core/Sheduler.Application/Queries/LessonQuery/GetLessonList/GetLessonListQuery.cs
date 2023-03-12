using MediatR;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonList;

public class GetLessonListQuery : IRequest<LessonListVm>
{
    public Guid UserId { get; set; }
}