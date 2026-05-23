using MediatR;
using VacanciesProject.Application.ViewModel;
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Application.Features.TaskFeatures.CreateTask.Command;

public record CreateTaskCommand
(
	string Title,
	string Description,
	DateTime? DueDate,
	Priority Priority,
	int ProjectId
)
: IRequest<ResponseViewModel<int>>;