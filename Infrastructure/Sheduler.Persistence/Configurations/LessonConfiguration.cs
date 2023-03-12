using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Domain.Models;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(lesson => lesson.Id);
        builder.HasIndex(lesson => lesson.Id).IsUnique();
        builder.Property(lesson => lesson.Title).IsRequired();
        builder.Property(lesson => lesson.Teacher)
            .HasConversion(
                 teacher => JsonSerializer.Serialize(teacher, JsonSerializerOptions.Default),
                value => JsonSerializer.Deserialize<Teacher>(value, JsonSerializerOptions.Default));
        builder.Property(lesson => lesson.LessonType)
            .HasConversion(
                lessonType => lessonType.ToString(),
                value => (LessonType)Enum.Parse(typeof(LessonType), value));
        builder.Property(lesson => lesson.UserId).IsRequired();
        builder.Property(lesson => lesson.DateTime).IsRequired();
    }
}