using MediatR;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherDetails;

public class GetTeacherDetailsQuery : IRequest<TeacherDetailsVm>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}