using VacanciesProject.Application.Interfaces.Services;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Services;

public class AuditLogService : IAuditLogService
{
	private readonly IAuditLogRepository _repository;

	public AuditLogService(IAuditLogRepository repository)
	{
		_repository = repository;
	}

	public async Task LogAsync(
		int? userId,
		string action,
		string entityName,
		int? entityId = null,
		CancellationToken cancellationToken = default)
	{
		var auditLog = new AuditLog
		{
			UserId = userId,
			Action = action,
			EntityName = entityName,
			EntityId = entityId
		};

		await _repository.AddAsync(auditLog, cancellationToken);
	}
}

