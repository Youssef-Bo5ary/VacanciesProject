
namespace VacanciesProject.Application.Interfaces.Services;

public interface IAuditLogService
{
	Task LogAsync(
		int? userId,
		string action,
		string entityName,
		int? entityId = null,
		CancellationToken cancellationToken = default);
}
