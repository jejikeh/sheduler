using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.UpdateTeacher(request.TeacherName, request.UserId, request.NewName);
        return teacher;
    }
}