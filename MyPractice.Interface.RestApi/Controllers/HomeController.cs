using Microsoft.AspNetCore.Mvc;

namespace MyPractice.Interface.RestApi.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase // neccessary for using Ok ,NotFound
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hi");
    }
}