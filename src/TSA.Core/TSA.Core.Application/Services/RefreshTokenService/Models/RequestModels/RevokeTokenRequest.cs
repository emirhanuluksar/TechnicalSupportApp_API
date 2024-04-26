namespace TSA.Core.Application.Services.RefreshTokenService.Models.RequestModels;

public record RevokeTokenRequest(string Token)
{
    public string IpAddress { get; set; } = string.Empty;

    public RevokeTokenRequest() : this("")
    {
    }
}