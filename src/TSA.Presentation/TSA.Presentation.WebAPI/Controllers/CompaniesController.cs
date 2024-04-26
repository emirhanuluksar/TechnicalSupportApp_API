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
    public IActionResult GetCompanyById([FromRoute] Guid companyId)
    {
        return Ok(companyId);
    }

    [HttpPost("createCompany")]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateCompany([FromForm] CreateCompanyRequest request)
    {
        return Ok(request);
    }

    [HttpPut("updateCompany")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateCompany([FromForm] UpdateCompanyRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("deleteCompany/{companyId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteCompany([FromRoute] Guid companyId)
    {
        return Ok(companyId);
    }

}
