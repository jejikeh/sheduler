using Microsoft.EntityFrameworkCore;
using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common;

public class TeacherContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
   
    public static Guid TeacherForDelete = Guid.NewGuid();
    public static Guid TeacherForUpdate = Guid.NewGuid();

    public static TeachersDbContext Create()
    {
        var options = new DbContextOptionsBuilder<TeachersDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new TeachersDbContext(options);
        context.Database.EnsureCreated();
        
        context.Set().AddRange(
            new Teacher(UserAId, "Ivanov", Guid.Parse("FC986B32-DA05-4F78-A737-DE48356E2F07")),
            new Teacher(UserAId, "Metrov", Guid.Parse("D04E68C5-88F2-404F-8503-4CEB68DC4185")),
            new Teacher(UserBId, "Petrov", Guid.Parse("182D4620-8FF4-49AF-AD1F-2152A3239782")),
            new Teacher(UserBId, "Kelkov", Guid.Parse("4B3FDDDD-8885-4CBB-8187-A96917605B7E")));
        context.SaveChanges();
        return context;
    }

    public static void Destroy(TeachersDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}