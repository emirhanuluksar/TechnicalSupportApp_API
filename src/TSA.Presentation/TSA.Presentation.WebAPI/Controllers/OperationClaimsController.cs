using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOperationClaims()
    {
        return Ok();
    }

    [HttpGet("getOperationClaimById/{operationClaimId}")]
    public IActionResult GetOperationClaimById([FromRoute] Guid operationClaimId)
    {
        return Ok(operationClaimId);
    }

    [HttpPost("createOperationClaim")]
    public IActionResult CreateOperationClaim([FromForm] CreateOperationClaimRequest request)
    {
        return Ok(request);
    }

    [HttpPut("updateOperationClaim")]
    public IActionResult UpdateOperationClaim([FromForm] UpdateOperationClaimRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("deleteOperationClaim/{operationClaimId}")]
    public IActionResult DeleteOperationClaim([FromRoute] Guid operationClaimId)
    {
        return Ok(operationClaimId);
    }
}

public class UpdateOperationClaimRequest
{
}

public class CreateOperationClaimRequest
{
}