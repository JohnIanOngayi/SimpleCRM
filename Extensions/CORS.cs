namespace SimpleCRM.Extensions
{
	/// <summary>
	/// Provides extension methods for configuring CORS in the application.
	/// </summary>
	public static class CORS
	{
		/// <summary>
		/// Configures Cross-Origin Resource Sharing (CORS) for the application.
		/// </summary>
		/// <param name="services">The IServiceCollection to add the CORS services to.</param>
		public static void ConfigureCORS(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});
		}
	}
}
