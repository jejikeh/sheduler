using Sheduler.Domain.Core.Primitives.Entities;
using Sheduler.Domain.Core.Utils;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Domain.Models;

public class Lesson : EntityGuid
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public Teacher Teacher { get; set; }
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }

    public Lesson(Guid userId, string title, Teacher teacher, LessonType lessonType, DateTime dateTime, Guid id) : base(id)
    {
        Ensure.NotNull(teacher, "The teacher is required", nameof(teacher));
        Ensure.NotNull(teacher, "The lessonType is required", nameof(lessonType));

        UserId = userId;
        Title = title;
        Teacher = teacher;
        LessonType = lessonType;
        DateTime = dateTime;
    }
}