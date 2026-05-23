using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VacanciesProject.Infrastructure.Persistance
{
	public class ApplicationDbContextFactory
		: IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder =
				new DbContextOptionsBuilder<ApplicationDbContext>();

			optionsBuilder.UseSqlServer(
				"Server = . ; DataBase = TasksProject ; Trusted_Connection = True ; TrustServerCertificate = True");

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}