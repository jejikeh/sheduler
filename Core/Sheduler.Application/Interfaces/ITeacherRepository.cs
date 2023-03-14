using Sheduler.Domain.Models;

namespace Sheduler.Application.Interfaces;

public interface ITeacherRepository
{
    public Task<ICollection<Teacher>> GetAllTeachers(int userId);
    public Task<Teacher> GetTeacherByName(string name, int userId);
    public Task<Teacher> CreateTeacher(int userId, string name);
    public Task<Teacher> UpdateTeacher(string teacherName, int userId, string newName);
    public Task DeleteTeacher(string name, int userId);

}