using Library.Domain.Entities;
using System.Security.Claims;

namespace Library.Application.Extensions;

public static class RoleClaimsExtensions
{
    public static List<Claim> GetClaims(this User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        return claims;
    }
}
