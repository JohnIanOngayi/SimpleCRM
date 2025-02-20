using SimpleCRM.Contracts;
using SimpleCRM.LoggerService;

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
	}
}
