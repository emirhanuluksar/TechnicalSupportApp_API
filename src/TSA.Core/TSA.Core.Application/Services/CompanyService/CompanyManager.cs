using AutoMapper;
using Microsoft.AspNetCore.Http;
using TSA.Core.Application.Repositories.Common;
using TSA.Core.Application.Services.CompanyService.Constants;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;
using TSA.Core.Domain.Entities;
using TSA.Infrastructure.Infrastructure.FileHelper;

namespace TSA.Core.Application.Services.CompanyService;

public class CompanyManager(IUnitOfWork unitOfWork, IMapper mapper) : ICompanyService
{
    public async Task<CreatedCompanyResponse> CreateCompany(CreateCompanyRequest request)
    {
        // Add business logic here
        var (logoUrl, coverImageUrl) = await PrepareCompanyImagesAsync(request.Logo, request.CoverImage);
        var company = mapper.Map<Company>(request);
        company.CoverImageUrl = coverImageUrl;
        company.LogoUrl = logoUrl;
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

    private async Task<(string logoUrl, string coverImageUrl)> PrepareCompanyImagesAsync(IFormFile? logo, IFormFile? coverImage)
    {
        string logoUrl = string.Empty;
        string coverImageUrl = string.Empty;

        if (logo != null)
        {
            logoUrl = await CreateCompanyLogo(logo);
        }

        if (coverImage != null)
        {
            coverImageUrl = await CreateCompanyCoverImage(coverImage);
        }

        return (logoUrl, coverImageUrl);
    }

    private bool IsDevelopmentEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }

    private async Task<string> CreateCompanyLogo(IFormFile logo)
    {
        string basePath = PathConstants.BasePathForImagesFromUbuntu;
        string subPath = PathConstants.SubPathForLogosFromUbuntu;

        var fileHelper = new FileHelper(basePath, subPath);

        return await fileHelper.SaveFileAsync(logo);
    }


    private async Task<string> CreateCompanyCoverImage(IFormFile coverImage)
    {
        string basePath = PathConstants.BasePathForImagesFromUbuntu;
        string subPath = PathConstants.SubPathForCoverImagesFromUbuntu;


        var fileHelper = new FileHelper(basePath, subPath);

        return await fileHelper.SaveFileAsync(coverImage);
    }


}
