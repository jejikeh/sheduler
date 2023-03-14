using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQueries.GetAllTeachers;

public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, ICollection<Teacher>>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task<ICollection<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        return await _teacherRepository.GetAllTeachers(request.UserId);
    }
}