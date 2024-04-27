using AutoMapper;
using TSA.Core.Application.Services.CompanyService.Models.QueryModels;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;
using TSA.Core.Application.Services.CompanyService.Models.ResponseModels;
using TSA.Core.Domain.Entities;

namespace TSA.Core.Application.Services.CompanyService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, GetCompaniesResponseModel>().ReverseMap();
        CreateMap<Company, CreatedCompanyResponse>().ReverseMap();
        CreateMap<Company, CreateCompanyRequest>().ReverseMap();
        CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyRequest>().ReverseMap();
        CreateMap<Company, GetCompanyByIdResponseModel>().ReverseMap();


    }
}