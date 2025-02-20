using System.ComponentModel.DataAnnotations;

namespace SimpleCRM.Entities.Models
{
	/// <summary>
	/// Represents a customer in the SimpleCRM system.
	/// </summary>
	public class Customer
	{
		/// <summary>
		/// Gets or sets the unique identifier for the customer.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the first name of the customer.
		/// </summary>
		[Required(ErrorMessage = "First name is required")]
		[StringLength(60, ErrorMessage = "First name cannot be longer than 60 characters")]
		public string? FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the customer.
		/// </summary>
		[Required(ErrorMessage = "Last name is required")]
		[StringLength(60, ErrorMessage = "Last name cannot be longer than 60 characters")]
		public string? LastName { get; set; }

		/// <summary>
		/// Gets or sets the phone number of the customer.
		/// </summary>
		[Required(ErrorMessage = "Phone number is required")]
		[StringLength(16, ErrorMessage = "Invalid Phone number")]
		public string? Phone { get; set; }

		/// <summary>
		/// Gets or sets the city where the customer resides.
		/// </summary>
		public string? City { get; set; }

		/// <summary>
		/// Gets or sets the state where the customer resides.
		/// </summary>
		public string? State { get; set; }

		/// <summary>
		/// Gets or sets the address of the customer.
		/// </summary>
		public string? Address { get; set; }
	}
}
