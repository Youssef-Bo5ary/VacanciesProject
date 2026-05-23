using VacanciesProject.Domain.Common;
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Domain.Entity;

public class Taskss : BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }
	public WorkTaskStatus Status { get; set; }
	public DateTime? DueDate { get; set; }
	public Priority Priority { get; set; }
	public int ProjectId { get; set; }

	public Project Project { get; set; }
}
