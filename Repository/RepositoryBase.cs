using SimpleCRM.Contracts;
using SimpleCRM.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace SimpleCRM.Repository
{
	/// <summary>
	/// Provides a base implementation for repository pattern.
	/// </summary>
	/// <typeparam name="T">The type of the entity.</typeparam>
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		/// <summary>
		/// Gets or sets the repository context.
		/// </summary>
		protected RepositoryContext Repository { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
		/// </summary>
		/// <param name="repository">The repository context.</param>
		public RepositoryBase(RepositoryContext repository) => Repository = repository;

		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>An <see cref="IQueryable{T}"/> of all entities.</returns>
		public IQueryable<T> FindAll() => Repository.Set<T>().AsNoTracking();

		/// <summary>
		/// Finds entities by the specified condition.
		/// </summary>
		/// <param name="expression">The condition to filter entities.</param>
		/// <returns>An <see cref="IQueryable{T}"/> of entities that match the condition.</returns>
		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
			Repository.Set<T>().Where(expression).AsNoTracking();

		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		public void Create(T entity) => Repository.Set<T>().Add(entity);

		/// <summary>
		/// Updates an existing entity.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		public void Update(T entity) => Repository.Set<T>().Update(entity);

		/// <summary>
		/// Deletes an entity.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		public void Delete(T entity) => Repository.Set<T>().Remove(entity);
	}
}
