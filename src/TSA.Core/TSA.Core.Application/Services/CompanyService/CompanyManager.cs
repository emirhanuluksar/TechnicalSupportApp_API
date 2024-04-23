using AutoMapper;
using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;
using TSA.Core.Domain.Entities;

namespace TSA.Core.Application.Services.CompanyService;

public class CompanyManager(IUnitOfWork unitOfWork, IMapper mapper) : ICompanyService
{
    public async Task<CreatedCompanyResponse> CreateCompany(CreateCompanyRequest request)
    {
        // Add business logic here
        var company = mapper.Map<Company>(request);
        var createdCompany = await unitOfWork.CompanyRepository.AddAsync(company);
        var mappedResponse = mapper.Map<CreatedCompanyResponse>(createdCompany);
        return mappedResponse;
    }

    public async Task<IEnumerable<GetCompaniesResponseModel>> GetCompanies()
    {
        var companies = await unitOfWork.CompanyRepository.GetListAsync();
        var mappedCompanies = mapper.Map<IEnumerable<GetCompaniesResponseModel>>(companies);
        return mappedCompanies;
    }
}
