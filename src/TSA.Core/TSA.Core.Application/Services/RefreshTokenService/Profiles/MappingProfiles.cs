using AutoMapper;
using TSA.Core.Application.Services.RefreshTokenService.Models.ResponseModels;
using TSA.Infrastructure.Security.Entities;

namespace TSA.Core.Application.Services.RefreshTokenService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
    }
}
