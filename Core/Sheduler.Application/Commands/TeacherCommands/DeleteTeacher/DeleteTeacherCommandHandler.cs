using MediatR;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private ITeachersDbContext _teachersDbContext;

    public DeleteTeacherCommandHandler(ITeachersDbContext teachersDbContext)
    {
        _teachersDbContext = teachersDbContext;
    }
    
    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _teachersDbContext.Set()
            .FindAsync(request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Teacher), request.Id);

        _teachersDbContext.Set().Remove(entity);
        await _teachersDbContext.SaveChangesAsync(cancellationToken);
    }
}