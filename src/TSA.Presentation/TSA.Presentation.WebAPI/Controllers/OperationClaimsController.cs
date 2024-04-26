using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetOperationClaims()
    {
        return Ok();
    }

    [HttpGet("getOperationClaimById/{operationClaimId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetOperationClaimById([FromRoute] Guid operationClaimId)
    {
        return Ok(operationClaimId);
    }

    // [HttpPost("createOperationClaim")]
    // public IActionResult CreateOperationClaim([FromForm] CreateOperationClaimRequest request)
    // {
    //     return Ok(request);
    // }

    // [HttpPut("updateOperationClaim")]
    // public IActionResult UpdateOperationClaim([FromForm] UpdateOperationClaimRequest request)
    // {
    //     return Ok(request);
    // }

    [HttpDelete("deleteOperationClaim/{operationClaimId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteOperationClaim([FromRoute] Guid operationClaimId)
    {
        return Ok(operationClaimId);
    }
}