using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Domain.Models;

namespace Sheduler.Persistence.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(teacher => teacher.Id);
        builder.HasIndex(teacher => teacher.Id).IsUnique();
        builder.Property(teacher => teacher.UserId).IsRequired();
        builder.Property(teacher => teacher.Name).IsRequired();
    }
}