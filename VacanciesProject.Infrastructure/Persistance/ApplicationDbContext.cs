using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Infrastructure.Persistance;
public class ApplicationDbContext
	: IdentityDbContext<AppUser, IdentityRole<int>, int>
	, IApplicationDbContext
{
	public ApplicationDbContext
		(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		//GetExecutingAssembly get all configurations and apply it

		base.OnModelCreating(modelBuilder);
	}

	
	public DbSet<AuditLog> auditLogs { get; set; }

	public DbSet<Project> Projects { get; set; }

	public DbSet<Taskss> Taskss { get; set; }
}
