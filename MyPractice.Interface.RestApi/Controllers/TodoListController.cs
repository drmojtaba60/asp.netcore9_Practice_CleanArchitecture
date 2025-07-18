using Microsoft.AspNetCore.Mvc;
using MyPractice.Application.Contract.Interfaces.Services;

namespace MyPractice.Interface.RestApi.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("todolists")]
public class TodoListController(ITodoListService todoListService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await todoListService.GetAllAsync();
        return Ok(result);
    }
}