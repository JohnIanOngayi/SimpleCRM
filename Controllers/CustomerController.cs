using SimpleCRM.Contracts;
using SimpleCRM.Entities.Models;
using SimpleCRM.Entities.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

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
		private readonly IMapper _mapper;
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerController"/> class.
		/// </summary>
		/// <param name="loggerManager">The logger manager.</param>
		/// <param name="repositoryWrapper">The repository wrapper.</param>
		public CustomerController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper, IMapper mapper)
		{
			_logger = loggerManager;
			_repository = repositoryWrapper;
			_mapper = mapper;
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
				var customersResult = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

				_logger.LogInfo("Returned all customers from the database.");

				return Ok(customersResult);
			}
			catch (Exception ex)
			{
				_logger.LogError($"GetAllCustomers Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}

		/// <summary>
		/// Gets a customer by the specified identifier.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>The customer with the specified identifier.</returns>
		[HttpGet("{id}", Name = "GetCustomerById")]
		public IActionResult GetCustomerById(int id)
		{
			try
			{
				var customer = _repository.Customer.GetCustomerById(id);
				if (customer is null)
				{
					_logger.LogInfo($"Customer with id: {id} non-existent");

					return NotFound();
				}
				var customerResult = _mapper.Map<CustomerDTO>(customer);
				
				_logger.LogInfo($"Returned customer with id: {id}");

				return Ok(customerResult);
			}
			catch (Exception ex)
			{
				_logger.LogError($"GetCustomerById Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}

		/// <summary>
		/// Creates a new customer.
		/// </summary>
		/// <param name="newCustomer">The customer creation DTO.</param>
		/// <returns>The created customer.</returns>
		[HttpPost]
		public IActionResult CreateCustomer([FromBody] CustomerCreationDTO newCustomer)
		{
			try
			{
				if (newCustomer is null)
				{
					_logger.LogError("Null Customer object from client");

					return BadRequest("Null Customer Object");
				}

				if (!ModelState.IsValid)
				{
					_logger.LogError("Invalid Customer object from client");

					return BadRequest("Invalid Customer Object");
				}

				var customerEntity = _mapper.Map<Customer>(newCustomer);

				_repository.Customer.CreateCustomer(customerEntity);
				_repository.Save();

				var createdCustomer = _mapper.Map<CustomerDTO>(customerEntity);

				return CreatedAtRoute("GetCustomerById", new { id = createdCustomer.Id }, createdCustomer);

			}
			catch (Exception ex)
			{
				_logger.LogError($"GetCustomerById Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}

		/// <summary>
		/// Deletes a customer by the specified identifier.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>No content if the customer was deleted.</returns>
		[HttpDelete("{id}")]
		public IActionResult DeleteCustomer(int id)
		{
			try
			{
				var customer = _repository.Customer.GetCustomerById(id);
				if (customer is null)
				{
					_logger.LogInfo($"Tried to delete non-existent customer id: {id}");

					return NotFound();
				}
				_repository.Customer.DeleteCustomer(customer);
				_repository.Save();

				return NoContent();

			}
			catch (Exception ex)
			{
				_logger.LogError($"DeleteCustomer Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}

		/// <summary>
		/// Updates a customer by the specified identifier.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <param name="customer">The customer update DTO.</param>
		/// <returns>No content if the customer was updated.</returns>
		[HttpPut("{id}")]
		public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDTO customer)
		{
			try
			{
				if (customer is null)
				{
					_logger.LogInfo($"Client passed null Customer object for Update");

					return BadRequest();
				}

				if (!ModelState.IsValid)
				{
					_logger.LogInfo($"Client passed invalid Customer object for Update");

					return BadRequest();
				}

				var customerExists = _repository.Customer.GetCustomerById(id);
				if (customerExists is null)
				{
					_logger.LogInfo($"Client tried updating non-existent Customer id: {id}");

					return NotFound();
				}

				_mapper.Map(customer, customerExists);
				_repository.Customer.UpdateCustomer(customerExists);
				_repository.Save();

				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError($"UpdateCustomer Action Error: {ex.Message}");

				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}
