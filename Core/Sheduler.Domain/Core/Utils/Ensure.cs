namespace Sheduler.Domain.Core.Utils;

public static class Ensure
{
    public static void GreaterThan<T>(T data, T compared, string message, string argumentName) where T : IComparable
    {
        if (data.CompareTo(compared) <= 0)
            throw new ArgumentException(message, argumentName);
    }
    
    public static void NotNull(object value, string message, string argumentName)
    {
        if (value is null)
            throw new ArgumentNullException(message, argumentName);
    }
}