using System.Collections.Immutable;
using System.Security.Claims;

namespace TSA.Infrastructure.Security.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static ICollection<string>? GetClaims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        return claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToImmutableArray();
    }

    /// <summary>
    /// Get all <see cref="ClaimTypes.Role"/> claims.
    /// </summary>
    public static ICollection<string>? GetRoleClaims(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.GetClaims(ClaimTypes.Role);
    }

    /// <summary>
    /// Get the <see cref="ClaimTypes.NameIdentifier"/> claim.
    /// </summary>
    public static string? GetIdClaim(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var claimValue = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (claimValue != null && Guid.TryParse(claimValue, out Guid resultGuid))
        {
            return resultGuid;
        }

        return Guid.Empty;
    }
}