using System.Linq.Expressions;

// TODO: Replace with asynchronous methods

namespace SimpleCRM.Contracts
{
	/// <summary>
	/// Interface for a generic repository that provides basic CRUD operations.
	/// </summary>
	/// <typeparam name="T">The type of the entity.</typeparam>
	public interface IRepositoryBase<T>
	{
		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of all entities.</returns>
		IQueryable<T> FindAll();

		/// <summary>
		/// Finds entities based on a condition.
		/// </summary>
		/// <param name="expression">The condition to filter the entities.</param>
		/// <returns>An <see cref="IQueryable{T}"/> of entities that match the condition.</returns>
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		void Create(T entity);

		/// <summary>
		/// Updates an existing entity.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		void Update(T entity);

		/// <summary>
		/// Deletes an entity.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void Delete(T entity);
	}
}
