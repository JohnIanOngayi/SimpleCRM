using SimpleCRM.Contracts;
using SimpleCRM.Entities;
using SimpleCRM.Entities.Models;

namespace SimpleCRM.Repository
{
	/// <summary>
	/// Provides the implementation for customer-specific repository operations.
	/// </summary>
	public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerRepository"/> class.
		/// </summary>
		/// <param name="repositoryContext">The context for the repository.</param>
		public CustomerRepository(RepositoryContext repositoryContext)
			: base(repositoryContext) { }
	}
}
