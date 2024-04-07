namespace Library.Core.Responses;

public class NoContentResponse<T> : ApiResponse<T>
{
    public NoContentResponse()
    {
        StatusCode = 204;
    }
}