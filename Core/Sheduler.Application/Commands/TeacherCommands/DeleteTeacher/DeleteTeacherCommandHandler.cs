using MediatR;
using Sheduler.Application.Interfaces;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly ITeacherRepository _teacherRepository;
    
    public DeleteTeacherHandler()
    
    public Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        await 
    }
}