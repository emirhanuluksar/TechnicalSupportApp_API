using System.Globalization;
using Microsoft.AspNetCore.Http;
using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Rules;
using TSA.Core.Application.Services.CompanyService.Constants;
using TSA.Core.Domain.Entities;
using TSA.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;
using TSA.Infrastructure.Infrastructure.FileService;

namespace TSA.Core.Application.Services.CompanyService.Rules;

public class CompanyBusinessRules(IUnitOfWork unitOfWork, IFileService fileService) : BaseBusinessRules
{
    public async Task<Company> AddPictureIfAny(Company company, IFormFile? coverImage, IFormFile? logo)
    {
        string coverImageUrl, logoUrl;
        if (coverImage is not null)
        {
            coverImageUrl = await fileService.SaveFileAsync(company.Id, coverImage, PathConstants.ServerCompanyCoverImagesPath);
            company.CoverImageUrl = coverImageUrl;
        }
        if (logo is not null)
        {
            logoUrl = await fileService.SaveFileAsync(company.Id, logo, PathConstants.ServerCompanyLogosPath);
            company.LogoUrl = logoUrl;
        }
        return company;
    }

    public async Task CompanyShouldBeExists(Guid id)
    {
        var company = await unitOfWork.CompanyRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (company is null)
        {
            throw new BusinessException("Company not found.");
        }
    }

    public async Task<Company> GetCompanyById(Guid id)
    {
        var company = await unitOfWork.CompanyRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (company is null)
        {
            throw new BusinessException("Company not found.");
        }
        return company;
    }

    public async Task<ICollection<Company>> SearchCompaniesAsync(string search, CancellationToken cancellationToken = default)
    {
        return await unitOfWork.CompanyRepository.SearchCompaniesAsync(search, cancellationToken);
    }

    public async Task CompanyNameShouldNotBeExists(string name)
    {
        var companies = await unitOfWork.CompanyRepository.GetListAsync();
        var result = companies.Any(c => c.Name.ToLowerInvariant() == name.ToLowerInvariant());
        if (result)
        {
            throw new BusinessException("Company name already exists.");
        }
    }
}