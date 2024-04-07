namespace Library.Core.Responses;

public class OkResponse<T> : ApiResponse<T>
{
    public OkResponse(T data)
    {
        Data = data;
        StatusCode = 200;
    }
}