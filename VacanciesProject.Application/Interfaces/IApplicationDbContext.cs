
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Interfaces;

public interface IApplicationDbContext
{
	public DbSet<Project> Projects { get; }
	public DbSet<Taskss> Taskss { get; }
	public DbSet<AuditLog> auditLogs { get; set; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
