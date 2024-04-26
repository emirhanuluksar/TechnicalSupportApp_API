using Microsoft.AspNetCore.Mvc;
using TSA.Infrastructure.Security.Extensions;
namespace TSA.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected string? getIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    protected Guid getUserIdFromRequest() //todo authentication behavior?
    {
        Guid userId = HttpContext.User.GetUserId();
        return userId;
    }
}