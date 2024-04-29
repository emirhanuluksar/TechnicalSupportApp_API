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
    public async Task<(string coverImageUrl, string logoUrl)> AddPictureIfAny(Guid companyId, IFormFile? coverImage, IFormFile? logo)
    {
        if (coverImage is null && logo is null)
        {
            throw new BusinessException("At least one picture must be uploaded.");
        }
        var coverImageUrl = await fileService.SaveFileAsync(companyId, coverImage!, PathConstants.ServerCompanyCoverImagesPath);
        var logoUrl = await fileService.SaveFileAsync(companyId, logo!, PathConstants.ServerCompanyLogosPath);
        return (coverImageUrl, logoUrl);
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