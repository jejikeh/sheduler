using Sheduler.Domain.Core.Primitives.Entities;

namespace Sheduler.Domain.Models;

public class Teacher : EntityGuid
{
    public Guid UserId;
    public string Name;
    
    public Teacher(Guid userId, string name, Guid id) : base(id)
    {
        UserId = userId;
        Name = name;
    }
}