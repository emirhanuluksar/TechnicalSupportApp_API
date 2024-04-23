using Microsoft.AspNetCore.Mvc;
using TSA.Core.Application.Services.CompanyService;
using TSA.Core.Application.Services.CompanyService.Models.RequestModels;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController(ICompanyService companyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await companyService.GetCompanies();
        return Ok(companies);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var company = await companyService.CreateCompany(request);
        return Created(uri: "", company);
    }
}
