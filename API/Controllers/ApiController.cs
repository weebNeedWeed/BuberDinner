using API.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKey.Errors] = errors;
        
        var firstError = errors.First();
        var (statusCode, title) = firstError.Type switch
        {
            ErrorType.Conflict => (StatusCodes.Status409Conflict, firstError.Description),
            ErrorType.Validation => (StatusCodes.Status400BadRequest, firstError.Description),
            ErrorType.NotFound => (StatusCodes.Status404NotFound, firstError.Description),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };
        
        return Problem(statusCode: statusCode, title: title);
    }
}