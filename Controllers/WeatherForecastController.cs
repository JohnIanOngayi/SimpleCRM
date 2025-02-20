using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Contracts;

namespace SimpleCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILoggerManager _logger;

    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        // Testing Logger
        _logger.LogInfo("An info message");
        _logger.LogDebug("A debug message");
        _logger.LogWarn("A warn message");
        _logger.LogError("An error message");

        return ["str1", "str2"];
    }
}
