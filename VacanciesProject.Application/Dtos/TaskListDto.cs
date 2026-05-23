
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Application.Dtos;


public class TaskListDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public WorkTaskStatus Status { get; set; }

	public DateTime? DueDate { get; set; }

	public Priority Priority { get; set; }
}
