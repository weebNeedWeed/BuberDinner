using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}