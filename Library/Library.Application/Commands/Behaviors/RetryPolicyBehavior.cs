using System.Reflection;
using Library.Application.Utils;
using Microsoft.Extensions.Logging;
using Polly;

namespace Library.Application.Commands.Behaviors;

public class RetryPolicyBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<RetryPolicyBehavior<TRequest, TResponse>> _logger;

    public RetryPolicyBehavior(ILogger<RetryPolicyBehavior<TRequest, TResponse>> logger)
        => _logger = logger;
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var retry = typeof(TRequest).GetCustomAttribute<RetryPolicyAttribute>();
        if (retry is null)
            return await next();
        
        return await Policy.Handle<ValidationException>()
            .WaitAndRetryAsync(
                retry.RetryCount,
                i => TimeSpan.FromMilliseconds(i * retry.SleepDuration),
                (ex, ts, _) => _logger.LogWarning(ex, "Failed to execute handler for request {Request}, retrying after {RetryTimeSpan}s: {ExceptionMessage}", typeof(TRequest).Name, ts.TotalSeconds, ex.Message))
            .ExecuteAsync(async () => await next());
    }
}