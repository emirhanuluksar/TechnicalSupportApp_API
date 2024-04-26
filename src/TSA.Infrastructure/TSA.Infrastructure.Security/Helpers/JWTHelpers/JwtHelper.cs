using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Extensions;
using TSA.Infrastructure.Security.Helpers.EncryptionHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TSA.Infrastructure.Security.Helpers.JWTHelpers;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        const string configurationSection = "TokenOptions";
        _tokenOptions =
            Configuration.GetSection(configurationSection).Get<TokenOptions>()
            ?? throw new InvalidOperationException($"\"{configurationSection}\" section cannot found in configuration.");
    }

    public virtual AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.UtcNow.AddMonths(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtSecurityToken jwt = CreateJwtSecurityToken(
            _tokenOptions,
            user,
            signingCredentials,
            operationClaims
        );
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken { Token = token, ExpirationDate = _accessTokenExpiration };
    }

    public RefreshToken CreateRefreshToken(User user, string ipAddress)
    {
        return new RefreshToken()
        {
            UserId = user.Id,
            Token = randomRefreshToken(),
            ExpirationDate = DateTime.UtcNow.AddDays(_tokenOptions.RefreshTokenTTL),
            CreatedByIp = ipAddress
        };
    }

    public virtual JwtSecurityToken CreateJwtSecurityToken(
        TokenOptions tokenOptions,
        User user,
        SigningCredentials signingCredentials,
        IList<OperationClaim> operationClaims
    )
    {
        return new JwtSecurityToken(
            tokenOptions.Issuer,
            tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.UtcNow,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
    }

    protected virtual IEnumerable<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
    {
        List<Claim> claims = [];
        claims.AddNameIdentifier(user!.Id!.ToString()!);
        claims.AddEmail(user.Email);
        claims.AddRoles(operationClaims.Select(c => c.OperationClaimName).ToArray());
        return claims;
    }

    private string randomRefreshToken()
    {
        byte[] numberByte = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}