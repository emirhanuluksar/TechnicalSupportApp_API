namespace TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;
public record RevokedTokenResponse(int Id, string Token)
{
    public RevokedTokenResponse() : this(0, "")
    {
    }
}
