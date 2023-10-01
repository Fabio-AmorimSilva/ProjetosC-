namespace Library.Domain.Entities.ErrorHandling;

public class Result
{
    public bool Success { get; }
    public string Message { get; }

    private Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static Result SuccessResult()
        => new(true, string.Empty);

    public static Result FailureResult(string message = "")
        => new(false, message);
}