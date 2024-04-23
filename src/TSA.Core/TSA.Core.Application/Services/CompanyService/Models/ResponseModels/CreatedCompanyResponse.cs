namespace TSA.Core.Application.Services.CompanyService.Models.ResponseModels;

public record CreatedCompanyResponse(Guid Id, string Name, string Email, string Description, string PhoneNumber, string WebSite)
{
    public CreatedCompanyResponse() : this(Guid.Empty, "", "", "", "", "")
    {
    }
}
