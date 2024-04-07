namespace Library.Application.ViewModels.Result;

public class ResultResponse<T>
{
    public T Data { get; init; }
    public List<string>? Errors { get; init; } = [];

    public ResultResponse(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultResponse(T data)
        => Data = data;

    public ResultResponse(List<string> errors)
        => Errors = errors;

    public ResultResponse(string error)
        => Errors.Add(error);

    public ResultResponse()
    {
    }
}
