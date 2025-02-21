using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SimpleCRM.Entities.DTOs
{
	/// <summary>
	/// Data Transfer Object for Customer entity.
	/// </summary>
	public class CustomerDTO
	{
		public int Id { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? City { get; set; }
	}

	/// <summary>
	/// Data Transfer Object for Customer entity creation.
	/// </summary>
	public class CustomerCreationDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[StringLength(60, ErrorMessage = "First name cannot be longer than 60 characters")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[StringLength(60, ErrorMessage = "Last name cannot be longer than 60 characters")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[StringLength(16, ErrorMessage = "Invalid Phone number")]
		public string? Phone { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? Address { get; set; }
	}
}
