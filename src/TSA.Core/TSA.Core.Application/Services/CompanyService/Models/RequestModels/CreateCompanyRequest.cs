using Microsoft.AspNetCore.Http;

namespace TSA.Core.Application.Services.CompanyService.Models.RequestModels;

public record CreateCompanyRequest(string Name, string Email, IFormFile? Logo, IFormFile? CoverImage, string Description, string PhoneNumber, string Website)
{
    public CreateCompanyRequest() : this("", "", null, null, "", "", "")
    {
    }
}