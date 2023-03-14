using MediatR;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQueries.GetAllTeachers;

public class GetAllTeachersQuery : IRequest<ICollection<Teacher>>
{
    public int UserId { get; set; }
}