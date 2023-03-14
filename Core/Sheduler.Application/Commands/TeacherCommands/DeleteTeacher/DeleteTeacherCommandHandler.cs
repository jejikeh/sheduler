using MediatR;
using Sheduler.Application.Interfaces;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly ITeacherRepository _teacherRepository;

    public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        await _teacherRepository.DeleteTeacher(request.Name, request.UserId);
    }
}