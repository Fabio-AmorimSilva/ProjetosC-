namespace Library.Core.Responses;

public class UnprocessableResponse<T> : ApiResponse<T>
{
    public UnprocessableResponse(string message)
    {
        Errors?.Add(message);
        StatusCode = 422;
    }
}