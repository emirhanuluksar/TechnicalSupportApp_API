using TSA.Core.Application.Services.AuthService.Models.RequestModels;
using TSA.Core.Application.Services.AuthService.Models.ResponseModels;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.AuthService;

public interface IAuthService
{
    Task<LoggedResponse> Login(LoginRequest loginRequest);
    Task<RegisteredResponse> Register(RegisterRequest registerRequest);
    Task<(AccessToken accessToken, RefreshToken refreshToken)> PrepareToAccessTokenForUser(User user, string ipAddress);
    Task<AccessToken> CreateAccessToken(User user);
}