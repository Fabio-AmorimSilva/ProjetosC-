namespace Library.Core.Responses;

public class ConflictResponse<T>: ApiResponse<T>
{
    public ConflictResponse(string message)
    {
        Errors?.Add(message);
        StatusCode = 409;
    }
}