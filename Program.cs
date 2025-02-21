using SimpleCRM.Extensions;
using Scalar.AspNetCore;
using NLog;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Set up Logging
		LogManager.Setup().LoadConfigurationFromFile
		(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

		// Add services to the container.
		builder.Services.ConfigureLoggerService(); // Configures the logging service
		builder.Services.ConfigureCORS(); // Configures Cross-Origin Resource Sharing (CORS) policy
		builder.Services.ConfigureSqliteContext(builder.Configuration); // Configures the SQLite database context
		builder.Services.ConfigureRepositoryWrapper(); // Configures the repository wrapper service
		builder.Services.ConfigureAutoMapper(); // Configures AutoMapper for object-object mapping
		builder.Services.AddControllers(); // Adds controllers to the services collection
		builder.Services.AddEndpointsApiExplorer(); // Adds API explorer for endpoint documentation
		builder.Services.AddSwaggerGen(); // Adds Swagger generator for API documentation

		var app = builder.Build();

		// Configure the HTTP request pipeline.

		// Configuring openapi Scala
		app.UseSwagger(options => options.RouteTemplate = "openapi/{documentName}.json");
		app.MapScalarApiReference(options =>
		{
			options.Title = "Simple CRM";
			options.Theme = ScalarTheme.Mars;
			options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
		});

		// app.UseHttpsRedirection();

		// app.UseStaticFiles();

		app.UseForwardedHeaders(new ForwardedHeadersOptions
		{
			ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
		});

		app.UseCors("CorsPolicy");

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}