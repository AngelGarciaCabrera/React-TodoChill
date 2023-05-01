using Domain.Authentication.Auth;
using Domain.Dtos.Dtos;
using Domain.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace de_todo_chill.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UsersController> _logger;
    private readonly AppAuthSettings _authSettings;

    public UsersController(ILogger<UsersController> logger, IUserService service,
        IOptions<AppAuthSettings> authSettings)
    {
        _logger = logger;
        _service = service;
        _authSettings = authSettings.Value;
    }

    [HttpGet("All/{page:int}/{maxRecords:int?}")]
    public Task<IActionResult> Get(int page, int? maxRecords)
    {
        return Task.FromResult<IActionResult>(Ok(
            _service.Get(page, maxRecords)
        ));
    }

    [HttpGet("{id:int}")]
    public Task<IActionResult> GetBy(int id)
    {
        return Task.FromResult<IActionResult>(Ok(
            _service.GetBy(id)
        ));
    }

    [HttpPost("Add")]
    public Task<IActionResult> Create([FromBody] UserDto user)
    {
        if (user.Id != 0)
        {
            return Task.FromResult<IActionResult>(
                BadRequest(new { message = "Entity field values not supported." })
            );
        }

        return Task.FromResult<IActionResult>(Created(
            "Created!",
            _service.Create(user)
        ));
    }

    [HttpPut("Update/{id:int}")]
    public Task<IActionResult> Update(int id, [FromBody] UserDto user)
    {
        if (id <= 0)
        {
            return Task.FromResult<IActionResult>(BadRequest(
                new { message = "Entity must contain valid fields." }
            ));
        }

        user.Id = id;

        return Task.FromResult<IActionResult>(Ok(
            _service.Update(user)
        ));
    }

    [HttpDelete("Remove/{id:int}")]
    public Task<IActionResult> Delete(int id)
    {
        if (id == 0)
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }

        return Task.FromResult<IActionResult>(Ok(
            _service.Delete(id)
        ));
    }
}