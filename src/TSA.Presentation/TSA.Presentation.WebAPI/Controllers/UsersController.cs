using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUsers()
    {
        return Ok();
    }

    [HttpGet("getUserById/{userId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUserById([FromRoute] Guid userId)
    {
        return Ok(userId);
    }

    // [HttpPost("createUser")]
    // public IActionResult CreateUser([FromBody] CreateUserRequest request)
    // {
    //     return Ok(request);
    // }

    // [HttpPut("updateUser")]
    // public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
    // {
    //     return Ok(request);
    // }

    [HttpDelete("deleteUser/{userId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUser([FromRoute] Guid userId)
    {
        return Ok(userId);
    }
}