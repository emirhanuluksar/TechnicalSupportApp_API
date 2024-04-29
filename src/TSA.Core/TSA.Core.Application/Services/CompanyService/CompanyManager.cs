using AutoMapper;
using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Services.CompanyService.Models.QueryModels;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;
using TSA.Core.Application.Services.CompanyService.Rules;
using TSA.Core.Domain.Entities;

namespace TSA.Core.Application.Services.CompanyService;

public class CompanyManager(IUnitOfWork unitOfWork, IMapper mapper, CompanyBusinessRules companyBusinessRules) : ICompanyService
{
    public async Task<CreatedCompanyResponse> CreateCompany(CreateCompanyRequest request)
    {
        await companyBusinessRules.CompanyNameShouldNotBeExists(request.Name);
        var company = mapper.Map<Company>(request);
        var createdCompany = await unitOfWork.CompanyRepository.AddAsync(company);
        var imageUrls = await companyBusinessRules.AddPictureIfAny(createdCompany.Id, request.CoverImage, request.Logo);
        company.CoverImageUrl = imageUrls.coverImageUrl;
        company.LogoUrl = imageUrls.logoUrl;
        var updatedCompany = await unitOfWork.CompanyRepository.UpdateAsync(company);
        var mappedResponse = mapper.Map<CreatedCompanyResponse>(updatedCompany);
        return mappedResponse;
    }

    public async Task<UpdatedCompanyResponse> UpdateCompany(UpdateCompanyRequest request)
    {
        var company = await companyBusinessRules.GetCompanyById(request.Id);
        var mappedCompany = mapper.Map(request, company);
        var imageUrls = await companyBusinessRules.AddPictureIfAny(mappedCompany.Id, request.CoverImage, request.Logo);
        mappedCompany.CoverImageUrl = imageUrls.coverImageUrl;
        mappedCompany.LogoUrl = imageUrls.logoUrl;
        var updatedCompany = await unitOfWork.CompanyRepository.UpdateAsync(mappedCompany);
        var mappedResponse = mapper.Map<UpdatedCompanyResponse>(updatedCompany);
        return mappedResponse;
    }

    public async Task<IEnumerable<GetCompaniesResponseModel>> GetCompanies()
    {
        var companies = await unitOfWork.CompanyRepository.GetListAsync();
        var mappedCompanies = mapper.Map<IEnumerable<GetCompaniesResponseModel>>(companies);
        return mappedCompanies;
    }

    public async Task<DeletedCompanyResponse> DeleteCompany(DeleteCompanyRequest request)
    {
        var company = await companyBusinessRules.GetCompanyById(request.Id);
        await unitOfWork.CompanyRepository.DeleteAsync(company);
        DeletedCompanyResponse deletedCompanyResponse = new() { Id = request.Id };
        return deletedCompanyResponse;
    }

    public async Task<GetCompanyByIdResponseModel> GetCompanyById(Guid companyId)
    {
        var company = await companyBusinessRules.GetCompanyById(companyId);
        var mappedCompany = mapper.Map<GetCompanyByIdResponseModel>(company);
        return mappedCompany;
    }

    public async Task<ICollection<GetCompaniesResponseModel>> SearchCompaniesAsync(string search, CancellationToken cancellationToken = default)
    {
        var companies = await companyBusinessRules.SearchCompaniesAsync(search, cancellationToken);
        var mappedCompanies = mapper.Map<ICollection<GetCompaniesResponseModel>>(companies);
        return mappedCompanies;
    }
}
