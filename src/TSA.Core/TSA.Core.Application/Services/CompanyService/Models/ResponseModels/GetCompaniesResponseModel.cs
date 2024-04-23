namespace TSA.Core.Application.Services.CompanyService.Models.ResponseModels;

public record GetCompaniesResponseModel
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Website { get; init; } = string.Empty;
}