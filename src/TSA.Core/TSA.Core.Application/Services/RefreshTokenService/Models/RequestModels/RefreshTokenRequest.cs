namespace TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;

public record RefreshTokenRequest(string RefreshToken)
{
    public string IpAddress { get; set; } = string.Empty;
    public RefreshTokenRequest() : this("")
    {
    }
}