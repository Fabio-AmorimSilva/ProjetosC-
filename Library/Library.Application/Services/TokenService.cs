namespace Library.Application.Services;

public class TokenService(IOptions<JwtConfigurationSettings> settings)
{
    private readonly JwtConfigurationSettings _jwtConfigurationSettings = settings.Value;

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfigurationSettings.JwtKey);
        var claims = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtConfigurationSettings.ExpireMinutes),
            Issuer = _jwtConfigurationSettings.Emissary,
            Audience = _jwtConfigurationSettings.ValidOn,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
