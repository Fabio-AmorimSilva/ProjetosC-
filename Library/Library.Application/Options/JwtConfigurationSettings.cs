namespace Library.Application.Options;

public sealed class JwtConfigurationSettings
{
    public string JwtKey { get; init; } = string.Empty;
    public double ExpireMinutes { get; init; }
    public string Emissary { get; init; } = string.Empty;
    public string ValidOn { get; init; } = string.Empty;
}
