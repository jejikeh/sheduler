using MediatR;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

public class GetTeacherListQuery : IRequest<TeacherListVm>
{
    public Guid UserId { get; set; }
}