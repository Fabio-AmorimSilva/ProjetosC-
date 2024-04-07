namespace Library.Core.Responses;

public class NotFoundResponse<T> : ApiResponse<T>
{
    public NotFoundResponse(string message)
    {
        Errors?.Add(message);
        StatusCode = 404;
    }
}