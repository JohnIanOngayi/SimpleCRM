using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Contracts;

namespace SimpleCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILoggerManager _logger;

    private readonly IRepositoryWrapper _repository;

    public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        // Testing RepositoryWrapper
        var customers = _repository.Customer.FindAll();
        var laCustomers = _repository.Customer.FindByCondition(c => c.City.Equals("New York"));

        return ["str1", "str2"];
    }
}
