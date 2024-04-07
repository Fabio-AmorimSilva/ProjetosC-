namespace Library.Core.Responses;

public abstract class ApiResponse<T> : ResultResponse<T>
{
    public int? StatusCode { get; set; }
}