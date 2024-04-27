namespace TSA.Core.Application.Services.CompanyService.Models.ResponseModels;
public record UpdatedCompanyResponse(Guid Id, string Name, string Email, string LogoUrl, string CoverImageUrl, string Address, string Description, string PhoneNumber, string Website)
{
    public UpdatedCompanyResponse() : this(Guid.Empty, "", "", "", "", "", "", "", "")
    {
    }
}