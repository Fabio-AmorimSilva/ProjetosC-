namespace Library.WebApi.Filters.Exceptions;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        if (exception.GetType() != typeof(ValidationException)) 
            return;
        
        var error = new Error
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity,
            Message = exception.Message
        };
        context.Result = new JsonResult(error);
    }
}