using SimpleCRM.Repository;

namespace SimpleCRM.Contracts
{
	/// <summary>
	/// Interface for a repository wrapper that provides access to various repositories.
	/// </summary>
	public interface IRepositoryWrapper
	{
		/// <summary>
		/// Gets the customer repository.
		/// </summary>
		ICustomerRepository Customer { get; }

		/// <summary>
		/// Saves all changes made in the context to the database.
		/// </summary>
		void Save();
	}
}
