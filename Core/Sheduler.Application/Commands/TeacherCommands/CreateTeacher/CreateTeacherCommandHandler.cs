using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.Teachers;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task<Teacher> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Name = request.Name
        };

        return await _teacherRepository.CreateTeacher(teacher);
    }
}