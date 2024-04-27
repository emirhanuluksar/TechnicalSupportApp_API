using TSA.Core.Application.Services.CompanyService.Models.QueryModels;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;

namespace TSA.Core.Application.Services.CompanyService;

public interface ICompanyService
{
    Task<CreatedCompanyResponse> CreateCompany(CreateCompanyRequest request);
    Task<UpdatedCompanyResponse> UpdateCompany(UpdateCompanyRequest request);
    Task<DeletedCompanyResponse> DeleteCompany(DeleteCompanyRequest request);
    Task<IEnumerable<GetCompaniesResponseModel>> GetCompanies();
    Task<GetCompanyByIdResponseModel> GetCompanyById(Guid companyId);
}