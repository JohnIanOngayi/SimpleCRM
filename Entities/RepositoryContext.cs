using SimpleCRM.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRM.Entities
{
	/// <summary>
	/// Represents the database context for the repository.
	/// </summary>
	public class RepositoryContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RepositoryContext"/> class.
		/// </summary>
		/// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
		public RepositoryContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// Gets or sets the Customers DbSet.
		/// </summary>
		public DbSet<Customer>? Customers { get; set; }

		/// <summary>
		/// Configures the model that was discovered by convention from the entity types
		/// exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Customer>()
				.HasData(
				new Customer
				{
					Id = 3,
					FirstName = "Stan",
					LastName = "Rizzo",
					City = "New York",
					State = "New York",
					Address = "123 Main Street",
					Phone = "1234567890"
				},
				new Customer
				{
					Id = 5,
					FirstName = "Jane",
					LastName = "Seagel",
					City = "New York",
					State = "New York",
					Address = "345 Jane Street",
					Phone = "0123456789"
				},
				new Customer
				{
					Id = 4,
					FirstName = "Megan",
					LastName = "Draper",
					City = "Los Angeles",
					State = "California",
					Address = "467 Melon Drive",
					Phone = "9012345678"
				},
				new Customer
				{
					Id = 1,
					FirstName = "Donald",
					LastName = "Draper",
					City = "New York",
					State = "New York",
					Address = "892 Long Island",
					Phone = "8901234567"
				},
				new Customer
				{
					Id = 2,
					FirstName = "Roger",
					LastName = "Sterling",
					City = "New York",
					State = "New York",
					Address = "589 Long Island",
					Phone = "7890123456"
				}
				);
		}
	}
}
