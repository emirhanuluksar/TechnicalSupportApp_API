using AutoMapper;
using Microsoft.Extensions.Configuration;
using TSA.Core.Application.Services.AuthService.Models.RequestModels;
using TSA.Core.Application.Services.AuthService.Models.ResponseModels;
using TSA.Core.Application.Services.AuthService.Rules;
using TSA.Core.Application.Services.RefreshTokenService;
using TSA.Core.Application.Services.UserOperationClaimService;
using TSA.Core.Application.Services.UserService;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.HashingHelpers;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly TokenOptions _tokenOptions;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;


    public AuthManager
    (
        AuthBusinessRules authBusinessRules,
        IUserOperationClaimService userOperationClaimService,
        ITokenHelper tokenHelper,
        IRefreshTokenService refreshTokenService,
        IConfiguration configuration,
        IMapper mapper,
        IUserService userService
    )
    {
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>() ?? throw new BusinessException("TokenOptions is not found in appsettings.json");
        _authBusinessRules = authBusinessRules;
        _userOperationClaimService = userOperationClaimService;
        _tokenHelper = tokenHelper;
        _refreshTokenService = refreshTokenService;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<LoggedResponse> Login(LoginRequest loginRequest)
    {
        var user = await _authBusinessRules.GetUserByUserName(loginRequest.UserName);
        await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, loginRequest.Password);
        var tokens = await PrepareToAccessTokenForUser(user, loginRequest.IpAddress);
        var mappedResult = _mapper.Map<LoggedResponse>(tokens);
        return mappedResult;
    }

    public async Task<RegisteredResponse> Register(RegisterRequest registerRequest)
    {
        await _authBusinessRules.UserShouldNotBeExist(registerRequest.UserName);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(registerRequest.Password, out passwordHash, out passwordSalt);
        User user = new User
        {
            Username = registerRequest.UserName,
            Email = registerRequest.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        var createdUser = await _userService.AddAsync(user);
        var tokens = await PrepareToAccessTokenForUser(createdUser, registerRequest.IpAddress);
        var mappedResult = _mapper.Map<RegisteredResponse>(tokens);
        return mappedResult;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimService.GetClaimsByUserId(user.Id);
        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public async Task<(AccessToken accessToken, RefreshToken refreshToken)> PrepareToAccessTokenForUser(User user, string ipAddress)
    {
        AccessToken createdAccessToken = await CreateAccessToken(user);
        RefreshToken createdRefreshToken = await _refreshTokenService.CreateRefreshToken(user, ipAddress);
        RefreshToken addedRefreshToken = await _refreshTokenService.AddRefreshToken(createdRefreshToken);
        await _refreshTokenService.DeleteOldRefreshTokens(user.Id, _tokenOptions.RefreshTokenTTL);
        return (createdAccessToken, addedRefreshToken);
    }
}