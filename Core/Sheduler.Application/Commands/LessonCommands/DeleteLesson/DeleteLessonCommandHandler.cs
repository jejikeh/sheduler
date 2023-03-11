using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.LessonCommands.DeleteLesson;

public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand>
{
    private readonly ILessonsDbContext _lessonsDbContext;

    public DeleteLessonCommandHandler(ILessonsDbContext lessonsDbContext)
    {
        _lessonsDbContext = lessonsDbContext;
    }
    
    public async Task Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _lessonsDbContext.Set()
            .FindAsync(request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Lesson), request.Id);

        _lessonsDbContext.Set().Remove(entity);
        await _lessonsDbContext.SaveChangesAsync(cancellationToken);
    }
}