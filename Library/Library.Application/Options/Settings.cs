namespace Library.Application.Options;

public class Settings
{
    public string JwtKey { get; set; }
    public double ExpireMinutes { get; set; }
    public string Emissary { get; set; }
    public string ValidOn { get; set; }
}
