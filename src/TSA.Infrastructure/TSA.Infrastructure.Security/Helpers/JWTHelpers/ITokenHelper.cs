using TSA.Infrastructure.Security.Entities;

namespace TSA.Infrastructure.Security.Helpers.JWTHelpers;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
}