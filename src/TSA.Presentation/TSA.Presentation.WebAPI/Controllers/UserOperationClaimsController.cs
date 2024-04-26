using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetUserOperationClaims()
    {
        return Ok();
    }

    [HttpGet("getUserOperationClaimById/{userOperationClaimId}")]
    public IActionResult GetUserOperationClaimById([FromRoute] Guid userOperationClaimId)
    {
        return Ok(userOperationClaimId);
    }

    [HttpPost("createUserOperationClaim")]
    public IActionResult CreateUserOperationClaim([FromBody] CreateUserOperationClaimRequest request)
    {
        return Ok(request);
    }

    [HttpPut("updateUserOperationClaim")]
    public IActionResult UpdateUserOperationClaim([FromBody] UpdateUserOperationClaimRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("deleteUserOperationClaim/{userOperationClaimId}")]
    public IActionResult DeleteUserOperationClaim([FromRoute] Guid userOperationClaimId)
    {
        return Ok(userOperationClaimId);
    }
}

public class UpdateUserOperationClaimRequest
{
}

public class CreateUserOperationClaimRequest
{
}