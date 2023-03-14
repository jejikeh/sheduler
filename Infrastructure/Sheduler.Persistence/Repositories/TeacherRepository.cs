using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ShedulerDbContext _context;

    public TeacherRepository(ShedulerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Teacher>> GetAllTeachers(int userId)
    {
        var teachers = _context.Teachers
            .Where(teacher => teacher.UserId == userId);

        return await teachers.ToListAsync();
    }

    public async Task<Teacher> GetTeacherByName(string name, int userId)
    {
        var teacher = await _context.Teachers
            .FirstOrDefaultAsync(teacher => teacher.Name == name);

        if (teacher is null || teacher.UserId != userId )
            throw new NotFoundException<Teacher>(name);

        return teacher;
    }

    public async Task<Teacher> CreateTeacher(int userId, string name)
    {
        var teacher = new Teacher()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = name
        };
        
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task<Teacher> UpdateTeacher(string teacherName, int userId, string newName)
    {
        var teacher = await _context.Teachers
            .FirstOrDefaultAsync(lesson => lesson.Name == teacherName);

        if (teacher is null || teacher.UserId != userId )
            throw new NotFoundException<Teacher>(teacherName);

        teacher.Name = newName;
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task DeleteTeacher(string name, int userId)
    {
        var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Name == name);

        if (teacher is null || teacher.UserId != userId )
            throw new NotFoundException<Teacher>(name);

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
    }
}