using Domain.Contexts;
using Domain.Entities.Models;
using Domain.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace de_todo_chill.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("All/{page}/{maxRecords?}")]
    public async Task<IActionResult> Get(int page, int? maxRecords)
    {
        return Ok(
            _service.Get(page, maxRecords)
        );
    }
}