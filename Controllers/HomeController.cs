using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Contracts;

namespace SimpleCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILoggerManager _logger;

    public HomeController(ILoggerManager logger, IRepositoryWrapper repository)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var update = new { status = "ok" };
        //_logger.LogInfo("");
        return Ok(update);
    }
}
