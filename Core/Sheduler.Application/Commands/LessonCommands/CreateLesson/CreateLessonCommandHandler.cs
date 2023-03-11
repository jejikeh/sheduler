using MediatR;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Commands.LessonCommands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Guid>
{
    private readonly ILessonsDbContext _lessonsDbContext;
    private readonly ITeachersDbContext _teachersDbContext;

    public CreateLessonCommandHandler(ILessonsDbContext lessonsDbContext, ITeachersDbContext teachersDbContext)
    {
        _lessonsDbContext = lessonsDbContext;
        _teachersDbContext = teachersDbContext;
    }
    
    public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teachersDbContext.FindTeacherAsync(request.TeacherName);
        if (teacher is null)
            throw new NotFoundException(nameof(Teacher), request.TeacherName);

        var lesson = new Lesson(
            request.UserId,
            request.Title,
            teacher,
            request.LessonType,
            request.DateTime,
            Guid.NewGuid());

        await _lessonsDbContext.Set().AddAsync(lesson, cancellationToken);
        await _lessonsDbContext.SaveChangesAsync(cancellationToken);
        return lesson.Id;
    }
}