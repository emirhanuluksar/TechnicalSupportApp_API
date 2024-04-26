using Microsoft.IdentityModel.Tokens;

namespace TSA.Infrastructure.Security.Helpers.EncryptionHelpers;

public static class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
        new(securityKey, SecurityAlgorithms.HmacSha512Signature);
}