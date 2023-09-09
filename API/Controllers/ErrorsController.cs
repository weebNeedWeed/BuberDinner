using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ErrorsController : ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.GetRequiredFeature<IExceptionHandlerFeature>()!.Error;
        var title = exception.Message;
        var statusCode = StatusCodes.Status500InternalServerError;
        
        return Problem(title: title, statusCode: statusCode);
    }
}