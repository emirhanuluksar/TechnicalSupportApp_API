using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TSA.Core.Application.Services.AuthService;
using TSA.Core.Application.Services.AuthService.Models.RequestModels;
using TSA.Core.Application.Services.RefreshTokenService;
using TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;
using TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, IRefreshTokenService refreshTokenService) : BaseController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        loginRequest.IpAddress = getIpAddress();
        var result = await authService.Login(loginRequest);
        if (result.RefreshToken is not null)
            setRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.ToHttpResponse());
    }

    // [HttpPost("Register")]
    // public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    // {
    //     registerRequest.IpAddress = getIpAddress();
    //     var result = await authService.Register(registerRequest);
    //     setRefreshTokenToCookie(result.RefreshToken);
    //     return Created(uri: "", result.AccessToken);
    // }

    [HttpGet("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        RefreshTokenRequest refreshTokenRequest = new() { Token = getRefreshTokenFromCookies(), IpAddress = getIpAddress() };
        RefreshedTokensResponse refreshedTokensResponse = await refreshTokenService.RefreshToken(refreshTokenRequest);
        setRefreshTokenToCookie(refreshedTokensResponse.RefreshToken);
        return Created(uri: "", refreshedTokensResponse.AccessToken);
    }

    [HttpPut("RevokeToken")]
    public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] RevokeTokenRequest revokeTokenRequest)
    {
        revokeTokenRequest.IpAddress = getIpAddress();
        RevokedTokenResponse result = await refreshTokenService.RevokeToken(revokeTokenRequest);
        return Ok(result);
    }


    private string? getRefreshTokenFromCookies() => Request.Cookies["refreshToken"];

    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
    }
}