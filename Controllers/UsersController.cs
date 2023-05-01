using Domain.Contexts;
using Domain.Dtos.Dtos;
using Domain.Entities.Models;
using Domain.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace de_todo_chill.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("All/{page}/{maxRecords:int?}")]
    public async Task<IActionResult> Get(int page, int? maxRecords)
    {
        return Ok(
            _service.Get(page, maxRecords)
        );
    }
    
    [HttpGet("/{id}")]
    public async Task<IActionResult> GetBy(int id)
    {
        return Ok(
            _service.GetBy(id)
        );
    }
    
    [HttpPost("/Add")]
    public async Task<IActionResult> GetBy([FromBody] UserDto user)
    {
        if (user.Id != 0)
        {
            return BadRequest();
        }
        
        return Created(
            "",
            _service.Create(user)
        );
    }
}