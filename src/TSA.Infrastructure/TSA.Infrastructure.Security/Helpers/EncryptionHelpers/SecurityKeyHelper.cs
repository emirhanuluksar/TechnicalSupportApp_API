using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TSA.Infrastructure.Security.Helpers.EncryptionHelpers;

public static class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
}