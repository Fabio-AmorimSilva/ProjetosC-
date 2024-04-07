namespace Library.Core.Utils;

[AttributeUsage(AttributeTargets.Class)]
public class RetryPolicyAttribute : Attribute
{
    private int _retryCount = 3;
    private int _sleepDuration = 400;

    public int RetryCount => _retryCount;

    public int SleepDuration => _sleepDuration;
}