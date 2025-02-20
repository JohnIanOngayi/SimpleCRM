using Microsoft.EntityFrameworkCore;
using SimpleCRM.Entities;

namespace SimpleCRM.Extensions
{
	/// <summary>
	/// Provides extension methods for configuring database services.
	/// </summary>
	public static class DbService
	{
		/// <summary>
		/// Configures the SQLite context for the application.
		/// </summary>
		/// <param name="services">The service collection to add the context to.</param>
		/// <param name="config">The configuration to use for retrieving the connection string.</param>
		public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<RepositoryContext>(options =>
				options.UseSqlite(config.GetConnectionString("sqliteConnection")));
		}
	}
}
