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
}
