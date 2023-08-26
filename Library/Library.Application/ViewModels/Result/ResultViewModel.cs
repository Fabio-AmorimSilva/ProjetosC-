namespace Library.Application.ViewModels.Result;

public class ResultViewModel<T>
{
    public T Data { get; init; }
    public List<string>? Errors { get; init; }

    public ResultViewModel(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(T data)
        => Data = data;

    public ResultViewModel(List<string> errors)
        => Errors = errors;

    public ResultViewModel(string error)
        => Errors.Add(error);

    public ResultViewModel()
    {
    }
}
