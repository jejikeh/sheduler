using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQueries.GetTeacherById;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        return await _teacherRepository.GetTeacherByName(request.Name, request.UserId);
    }
}