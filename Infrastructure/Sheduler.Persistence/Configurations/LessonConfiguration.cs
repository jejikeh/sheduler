using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Domain.Models;

namespace Sheduler.Persistence.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(table => table.Id);
        builder.HasIndex(table => table.Id).IsUnique();
        builder.Property(table => table.Lessons).IsRequired();
    }
}