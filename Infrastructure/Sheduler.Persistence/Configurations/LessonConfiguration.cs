using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Domain.Models;

namespace Sheduler.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(lesson => lesson.Id);
        builder.HasIndex(lesson => lesson.Id).IsUnique();
        builder.Property(lesson => lesson.Title).IsRequired();
        builder.Property(lesson => lesson.UserId).IsRequired();
        builder.Property(lesson => lesson.DateTime).IsRequired();
    }
}