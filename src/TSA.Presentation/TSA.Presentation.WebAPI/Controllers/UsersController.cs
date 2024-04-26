using Microsoft.AspNetCore.Mvc;

namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok();
    }

    [HttpGet("getUserById/{userId}")]
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
    public IActionResult DeleteUser([FromRoute] Guid userId)
    {
        return Ok(userId);
    }
}