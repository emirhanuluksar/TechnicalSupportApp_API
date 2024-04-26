namespace TSA.Infrastructure.Security.Helpers.JWTHelpers;

public class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }

    /// <summary>
    /// Access token expiration time in minutes.
    /// </summary>
    public int AccessTokenExpiration { get; set; }

    public string SecurityKey { get; set; }

    /// <summary>
    /// Refresh token time in days.
    /// </summary>
    public int RefreshTokenTTL { get; set; }

    public TokenOptions()
    {
        Audience = string.Empty;
        Issuer = string.Empty;
        SecurityKey = string.Empty;
    }

    public TokenOptions(string audience, string issuer, int accessTokenExpiration, string securityKey, int refreshTokenTtl)
    {
        Audience = audience;
        Issuer = issuer;
        AccessTokenExpiration = accessTokenExpiration;
        SecurityKey = securityKey;
        RefreshTokenTTL = refreshTokenTtl;
    }
}