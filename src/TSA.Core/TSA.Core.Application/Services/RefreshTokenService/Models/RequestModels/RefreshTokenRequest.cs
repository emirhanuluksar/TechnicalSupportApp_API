namespace TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;

public record RefreshTokenRequest
{
    public string Token { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public RefreshTokenRequest()
    {
    }
}