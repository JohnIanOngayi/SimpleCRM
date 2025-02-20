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
		builder.Services.ConfigureLoggerService();
		builder.Services.ConfigureCORS();
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

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