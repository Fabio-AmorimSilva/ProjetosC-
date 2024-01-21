namespace Library.Application.Extensions;

public static class RoleClaimsExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Sid, user.Id.ToString()),
            new (ClaimTypes.Name, user.Email),
            new (ClaimTypes.Role, user.Role.ToString()),
        };

        return claims;
    }
}
