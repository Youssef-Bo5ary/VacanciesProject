using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Interfaces;

public interface IAuditLogRepository
{
	Task AddAsync(AuditLog auditLog, CancellationToken cancellationToken = default);

}
