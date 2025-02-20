using Microsoft.EntityFrameworkCore;
using SimpleCRM.Entities;

namespace SimpleCRM.Extensions
{
	public static class DbService
	{
		public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<RepositoryContext>(options =>
	options.UseSqlite(config.GetConnectionString("sqliteConnection")));
		}
	}
}
