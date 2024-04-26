using AutoMapper;
using TSA.Core.Application.Services.AuthService.Models.ResponseModels;
using TSA.Infrastructure.Security.Entities;
using TSA.Infrastructure.Security.Helpers.JWTHelpers;

namespace TSA.Core.Application.Services.AuthService.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<(AccessToken, RefreshToken), LoggedResponse>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.Item1))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.Item2))
            .ReverseMap();

        CreateMap<(AccessToken, RefreshToken), RegisteredResponse>()
            .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.Item1))
            .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.Item2))
            .ReverseMap();

    }
}