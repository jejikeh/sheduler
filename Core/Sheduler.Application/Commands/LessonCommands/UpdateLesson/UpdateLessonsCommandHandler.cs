using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonsCommandHandler : IRequestHandler<UpdateLessonCommand>
{
    private readonly ILessonsDbContext _lessonsDbContext;
    private readonly ITeachersDbContext _teachersDbContext;
    
    public UpdateLessonsCommandHandler(ILessonsDbContext lessonsDbContext, ITeachersDbContext teachersDbContext)
    {
        _lessonsDbContext = lessonsDbContext;
        _teachersDbContext = teachersDbContext;
    }
    
    public async Task Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _lessonsDbContext.Set()
            .FirstOrDefaultAsync(lesson => lesson.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Lesson), request.Id);

        var teacher = await _teachersDbContext.FindTeacherAsync(request.TeacherName);
        if (teacher is null)
            throw new NotFoundException(nameof(Teacher), request.TeacherName);
        
        entity.Title = request.Title;
        entity.LessonType = request.LessonType;
        entity.DateTime = request.DateTime;

        await _lessonsDbContext.SaveChangesAsync(cancellationToken);
    }
}