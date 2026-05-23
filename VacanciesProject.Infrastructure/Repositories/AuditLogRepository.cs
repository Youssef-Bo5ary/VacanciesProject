
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Domain.Entity;
using VacanciesProject.Infrastructure.Persistance;

namespace VacanciesProject.Infrastructure.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
	private readonly ApplicationDbContext _context;

	public AuditLogRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(AuditLog auditLog, CancellationToken cancellationToken = default)
	{
		await _context.auditLogs.AddAsync(auditLog, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
	}
}

