using SimpleCRM.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCRM.Controllers
{

	/// <summary>
	/// Controller for handling customer-related API requests.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ILoggerManager _logger;
		private readonly IRepositoryWrapper _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerController"/> class.
		/// </summary>
		/// <param name="loggerManager">The logger manager.</param>
		/// <param name="repositoryWrapper">The repository wrapper.</param>
		public CustomerController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
		{
			_logger = loggerManager;
			_repository = repositoryWrapper;
		}

		/// <summary>
		/// Gets all customers.
		/// </summary>
		/// <returns>A list of customers.</returns>
		[HttpGet]
		public IActionResult GetAllCustomers()
		{
			try
			{
				var customers = _repository.Customer.GetAllCustomers();
				_logger.LogInfo("Returned all customers from the database.");

				return Ok(customers);
			}
			catch (Exception ex)
			{
				_logger.LogError($"GetAllCustomers Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}
