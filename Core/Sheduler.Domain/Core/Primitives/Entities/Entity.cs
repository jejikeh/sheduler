namespace Sheduler.Domain.Core.Primitives.Entities;

public abstract class Entity<T> : IEquatable<Entity<T>>
{
    public T Id { get; protected init; }

    public bool Equals(Entity<T>? other)
    {
        if (other is null)
            return false;
        
        return ReferenceEquals(this, other) || ReferenceEquals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) 
            return false;
        
        if (ReferenceEquals(this, obj)) 
            return true;

        if (obj.GetType() != GetType())
            return false;

        return obj is Entity<T> entityObj && ReferenceEquals(Id, entityObj.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}