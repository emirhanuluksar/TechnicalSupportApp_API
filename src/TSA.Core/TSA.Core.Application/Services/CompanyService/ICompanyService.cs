using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;

namespace TSA.Core.Application.Services.CompanyService;

public interface ICompanyService
{
    Task<CreatedCompanyResponse> CreateCompany(CreateCompanyRequest request);
    Task<IEnumerable<GetCompaniesResponseModel>> GetCompanies();
}