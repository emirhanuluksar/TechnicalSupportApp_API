using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : ControllerBase
{

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUserOperationClaims()
    {
        return Ok();
    }

    [HttpGet("getUserOperationClaimById/{userOperationClaimId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUserOperationClaimById([FromRoute] Guid userOperationClaimId)
    {
        return Ok(userOperationClaimId);
    }

    // [HttpPost("createUserOperationClaim")]
    // public IActionResult CreateUserOperationClaim([FromBody] CreateUserOperationClaimRequest request)
    // {
    //     return Ok(request);
    // }

    // [HttpPut("updateUserOperationClaim")]
    // public IActionResult UpdateUserOperationClaim([FromBody] UpdateUserOperationClaimRequest request)
    // {
    //     return Ok(request);
    // }

    [HttpDelete("deleteUserOperationClaim/{userOperationClaimId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUserOperationClaim([FromRoute] Guid userOperationClaimId)
    {
        return Ok(userOperationClaimId);
    }
}