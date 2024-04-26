using System.Text.Json.Serialization;

namespace TSA.Core.Application.Services.AuthService.Models.RequestModels;

public record LoginRequest(string UserName, string Password)
{
    [JsonIgnore]
    public string IpAddress { get; set; } = string.Empty;

    public LoginRequest() : this("", "")
    {
    }
}
