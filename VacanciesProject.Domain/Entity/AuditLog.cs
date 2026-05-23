
using VacanciesProject.Domain.Common;

namespace VacanciesProject.Domain.Entity;

public class AuditLog : BaseEntity
{
	public string Action { get; set; } = string.Empty;
	public int? UserId { get; set; }
	public string EntityName { get; set; } = string.Empty;
	public int? EntityId { get; set; }

	public AppUser User { get; set; } = null!;
}
