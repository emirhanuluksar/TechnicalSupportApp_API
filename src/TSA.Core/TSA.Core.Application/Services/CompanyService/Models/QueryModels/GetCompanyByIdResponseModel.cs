namespace TSA.Core.Application.Services.CompanyService.Models.QueryModels;

public record GetCompanyByIdResponseModel(Guid Id, string Name, string Email, string LogoUrl, string CoverImageUrl, string Description, string PhoneNumber, string Website)
{
    public GetCompanyByIdResponseModel() : this(Guid.Empty, "", "", "", "", "", "", "")
    {
    }
}