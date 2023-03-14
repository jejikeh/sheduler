namespace Sheduler.Application.Common.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(object key) : base($"Entity {nameof(T)}, ({key}) not found")
    {
    }
}