namespace TSA.Core.Application.Services.CompanyService.Models.RequestModels;

public record DeleteCompanyRequest(Guid Id)
{
    public DeleteCompanyRequest() : this(Guid.Empty)
    {
    }
}