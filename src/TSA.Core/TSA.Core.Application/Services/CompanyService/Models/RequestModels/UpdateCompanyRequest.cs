using Microsoft.AspNetCore.Http;

namespace TSA.Core.Application.Services.CompanyService.Models.RequestModels;

public record UpdateCompanyRequest(Guid Id, string Name, string Email, IFormFile? Logo, IFormFile? CoverImage, string Address, string Description, string PhoneNumber, string Website)
{
    public UpdateCompanyRequest() : this(Guid.Empty, "", "", null, null, "", "", "", "")
    {
    }
}