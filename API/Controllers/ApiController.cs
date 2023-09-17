using API.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }
        
        if (errors.All(x => x.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }
        
        HttpContext.Items[HttpContextItemKey.Errors] = errors;
        
        return Problem(errors[0]);
    }

    private IActionResult Problem(Error error)
    {
        var (statusCode, title) = error.Type switch
        {
            ErrorType.Conflict => (StatusCodes.Status409Conflict, error.Description),
            ErrorType.Validation => (StatusCodes.Status400BadRequest, error.Description),
            ErrorType.NotFound => (StatusCodes.Status404NotFound, error.Description),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };
        
        return Problem(statusCode: statusCode, title: title);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDict = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDict.AddModelError(
                error.Code,
                error.Description);
        }
            
        return ValidationProblem(modelStateDict);
    }
}