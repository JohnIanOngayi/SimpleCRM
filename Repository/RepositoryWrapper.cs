using SimpleCRM.Contracts;
using SimpleCRM.Entities;

namespace SimpleCRM.Repository
{
	/// <summary>
	/// A wrapper class for the repository context that provides access to various repositories.
	/// </summary>
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private RepositoryContext repository;
		private ICustomerRepository customer;

		/// <summary>
		/// Initializes a new instance of the <see cref="RepositoryWrapper"/> class.
		/// </summary>
		/// <param name="repositoryContext">The repository context to be used by the wrapper.</param>
		public RepositoryWrapper(RepositoryContext repositoryContext)
		{
			repository = repositoryContext;
		}

		/// <summary>
		/// Gets the customer repository.
		/// </summary>
		public ICustomerRepository Customer
		{
			get
			{
				if (customer == null)
				{
					customer = new CustomerRepository(repository);
				}
				return customer;
			}
		}

		/// <summary>
		/// Saves all changes made in the context to the database.
		/// </summary>
		public void Save() => repository.SaveChanges();
	}
}
