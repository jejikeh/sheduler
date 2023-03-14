using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task<Teacher> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        return await _teacherRepository.CreateTeacher(request.UserId, request.Name);
    }
}