using MediatR;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQueries.GetTeacherById;

public class GetTeacherByIdQuery : IRequest<Teacher>
{
    public int UserId { get; set; }
    public string Name { get; set; }
}