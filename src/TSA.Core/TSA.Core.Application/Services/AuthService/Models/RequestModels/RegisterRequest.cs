namespace TSA.Core.Application.Services.AuthService.Models.RequestModels;

public record RegisterRequest(string UserName, string Password, string Email)
{
    public string IpAddress { get; set; } = string.Empty;

    public RegisterRequest() : this("", "", "")
    {
    }
}