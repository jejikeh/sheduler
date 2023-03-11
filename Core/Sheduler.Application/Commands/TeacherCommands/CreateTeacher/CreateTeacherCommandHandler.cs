using MediatR;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
{
    private readonly ITeachersDbContext _teachersDbContext;
    
    public CreateTeacherCommandHandler(ITeachersDbContext teachersDbContext)
    {
        _teachersDbContext = teachersDbContext;
    }
    
    public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher(
            request.UserId,
            request.Name,
            Guid.NewGuid());
        
        await _teachersDbContext.Set().AddAsync(teacher, cancellationToken);
        await _teachersDbContext.SaveChangesAsync(cancellationToken);
        return teacher.Id;
    }
}