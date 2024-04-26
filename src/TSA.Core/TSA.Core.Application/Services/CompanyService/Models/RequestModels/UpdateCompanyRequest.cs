using Microsoft.AspNetCore.Http;

namespace TSA.Core.Application.Services.CompanyService.Models.RequestModels;

public record UpdateCompanyRequest(string Name, string Email, IFormFile? Logo, IFormFile? CoverImage, string Description, string PhoneNumber, string Website)
{
    public UpdateCompanyRequest() : this("", "", null, null, "", "", "")
    {
    }
}