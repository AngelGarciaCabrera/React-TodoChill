using Domain.Contexts;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace de_todo_chill.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly MysqlDbContext _dbContext;
    private readonly ILogger<UserController> _logger;

    
    public UserController(ILogger<UserController> logger, MysqlDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetAllUsers")]

    public IEnumerable<User> Get([FromRoute] int page)
    {
        return null;
    }
    
}