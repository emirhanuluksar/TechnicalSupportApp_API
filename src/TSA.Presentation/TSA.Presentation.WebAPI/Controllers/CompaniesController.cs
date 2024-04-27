using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSA.Core.Application.Services.CompanyService;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await companyService.GetCompanies();
        return Ok(companies);
    }

    [HttpGet("getCompanyById/{companyId}")]
    public async Task<IActionResult> GetCompanyById([FromRoute] Guid companyId)
    {
        var response = await companyService.GetCompanyById(companyId);
        return Ok(response);
    }

    [HttpPost("createCompany")]
    public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyRequest request)
    {
        var response = await companyService.CreateCompany(request);
        return Created(uri: "", response);
    }

    [HttpPatch("updateCompany")]
    public async Task<IActionResult> UpdateCompany([FromForm] UpdateCompanyRequest request)
    {
        var response = await companyService.UpdateCompany(request);
        return Ok(response);
    }

    [HttpDelete("deleteCompany/{companyId}")]
    public async Task<IActionResult> DeleteCompany([FromRoute] Guid companyId)
    {
        DeleteCompanyRequest request = new() { Id = companyId };
        var response = await companyService.DeleteCompany(request);
        return Ok(response);
    }


}
