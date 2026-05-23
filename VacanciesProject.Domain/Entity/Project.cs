
using VacanciesProject.Domain.Common;

namespace VacanciesProject.Domain.Entity;

public class Project : BaseEntity
{
	public string Name { get; set; }
	public string Description { get; set; }
	public int UserId { get; set; }

	public AppUser User { get; set; }
	public ICollection<Taskss> Tasks { get; set; } = new List<Taskss>();

}
