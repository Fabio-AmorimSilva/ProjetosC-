namespace Library.Core.Messages;

public static class ErrorMessages
{
    public static string CannotBeEmpty(string field)
        => $"{field} cannot be empty.";

    public static string CannotBeNull(string field)
        => $"{field} cannot be null.";

    public static string HasMaxLength(string field, int length)
        => $"{field} length has to be less or equal to {length}.";

    public static string HasToBeGreaterThan(string field, int length)
        => $"{field} length has to be greater than {length}.";

    public static string NotFound<T>()
        => $"{typeof(T).Name} not found";

    public static string AlreadyExists(string field)
        => $"{field} already exists.";
}