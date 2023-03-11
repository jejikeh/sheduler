using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
{
    private ITeachersDbContext _teachersDbContext;

    public UpdateTeacherCommandHandler(ITeachersDbContext teachersDbContext)
    {
        _teachersDbContext = teachersDbContext;
    }
    
    public async Task Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _teachersDbContext.Set()
            .FirstOrDefaultAsync(lesson => lesson.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Teacher), request.Id);

        entity.Name = request.Name;
        await _teachersDbContext.SaveChangesAsync(cancellationToken);
    }
}