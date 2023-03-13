using Sheduler.Domain.Models;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Tests.Common;

public static class TestDataCollection
{
    public static Teacher[] Teachers = new []
    {
        new Teacher(DbContextFactory.UserAId, "Ivanov",
            Guid.Parse("FC986B32-DA05-4F78-A737-DE48356E2F07")),
        new Teacher(DbContextFactory.UserAId, "Metrov",
            Guid.Parse("D04E68C5-88F2-404F-8503-4CEB68DC4185")),
        new Teacher(DbContextFactory.UserBId, "Petrov",
            Guid.Parse("182D4620-8FF4-49AF-AD1F-2152A3239782")),
        new Teacher(DbContextFactory.UserBId, "Kelkov",
            Guid.Parse("4B3FDDDD-8885-4CBB-8187-A96917605B7E"))
    };
    
    public static Lesson[] Lessons = new []
    {
        new Lesson(
            DbContextFactory.UserAId, 
            "Math", 
            Teachers[0], 
            LessonType.Practice, 
            DateTime.MaxValue, 
            Guid.Parse("33D3A426-8EE9-4CDC-A35E-E059618674D6")),
        new Lesson(
            DbContextFactory.UserAId, 
            "Biology", 
            Teachers[1], 
            LessonType.Lecture, 
            DateTime.Now, 
            Guid.Parse("E1091B9F-9A81-41C1-9889-5882E191E6BA")),
        new Lesson(
            DbContextFactory.UserAId, 
            "English", 
            Teachers[2], 
            LessonType.Practice, 
            DateTime.MinValue, 
            Guid.Parse("F83C44EC-C36A-4190-80E5-210A7269C3C2")),
        new Lesson(
            DbContextFactory.UserBId, 
            "Geology", 
            Teachers[3], 
            LessonType.Lecture, 
            DateTime.Now, 
            Guid.Parse("1B65881A-8AB8-492B-A2C5-691FBFB13D66"))
        
    };
}