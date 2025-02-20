using SimpleCRM.Contracts;
using SimpleCRM.LoggerService;
using SimpleCRM.Repository;

namespace SimpleCRM.Extensions
{
	/// <summary>
	/// Provides extension methods for configuring services.
	/// </summary>
	public static class ServiceExtensions
	{
		/// <summary>
		/// Configures the logger service by adding a singleton of <see cref="ILoggerManager"/> and <see cref="LoggerManager"/>.
		/// </summary>
		/// <param name="services">The service collection to add the logger service to.</param>
		public static void ConfigureLoggerService(this IServiceCollection services)
		{
			services.AddSingleton<ILoggerManager, LoggerManager>();
		}

		/// <summary>
		/// Configures the repository wrapper by adding a scoped service of <see cref="IRepositoryWrapper"/> and <see cref="RepositoryWrapper"/>.
		/// </summary>
		/// <param name="services">The service collection to add the repository wrapper to.</param>
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}
	}
}
