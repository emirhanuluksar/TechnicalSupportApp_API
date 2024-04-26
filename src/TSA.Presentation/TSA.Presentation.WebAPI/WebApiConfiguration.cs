namespace TSA.Presentation.WebAPI;

public class WebApiConfiguration
{
    public string ApiDomain { get; set; } = string.Empty;
    public string[] AllowedOrigins { get; set; } = new string[] { };
}