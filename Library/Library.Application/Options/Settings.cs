﻿namespace Library.Application.Options;

public class Settings
{
    public string JwtKey { get; init; } = string.Empty;
    public double ExpireMinutes { get; init; }
    public string Emissary { get; init; } = string.Empty;
    public string ValidOn { get; init; } = string.Empty;
}
