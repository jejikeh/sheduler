using Sheduler.Domain.Core.Utils;

namespace Sheduler.Domain.Core.Primitives.Entities;

public abstract class EntityGuid : Entity<Guid>
{
    protected EntityGuid(Guid id)
    {
        Ensure.GreaterThan(id, Guid.Empty, "The entity guid must be greater than empty", nameof(id));
        Id = id;
    }
}