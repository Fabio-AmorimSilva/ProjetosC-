using Library.Core.Utils;

namespace Library.Core.Behaviors;

public class RetryPolicyBehavior<TRequest, TResponse>(ILogger<RetryPolicyBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var retry = typeof(TRequest).GetCustomAttribute<RetryPolicyAttribute>();
        if (retry is null)
            return await next();
        
        return await Policy.Handle<ValidationException>()
            .WaitAndRetryAsync(
                retry.RetryCount,
                i => TimeSpan.FromMilliseconds(i * retry.SleepDuration),
                (ex, ts, _) => logger.LogWarning(ex, "Failed to execute handler for request {Request}, retrying after {RetryTimeSpan}s: {ExceptionMessage}", typeof(TRequest).Name, ts.TotalSeconds, ex.Message))
            .ExecuteAsync(async () => await next());
    }
}