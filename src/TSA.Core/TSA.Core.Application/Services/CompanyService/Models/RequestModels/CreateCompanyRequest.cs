namespace TSA.Core.Application.Services.CompanyService.Models.RequestModels;

public record CreateCompanyRequest(string Name, string Email, string Description, string PhoneNumber, string Website)
{
    public CreateCompanyRequest() : this("", "", "", "", "")
    {
    }
}