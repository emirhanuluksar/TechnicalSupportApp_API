namespace TSA.Core.Application.Services.CompanyService.Models.ResponseModels;

public record DeletedCompanyResponse(Guid Id)
{
    public DeletedCompanyResponse() : this(Guid.Empty)
    {
    }
}