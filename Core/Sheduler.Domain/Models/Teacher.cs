namespace Sheduler.Domain.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}