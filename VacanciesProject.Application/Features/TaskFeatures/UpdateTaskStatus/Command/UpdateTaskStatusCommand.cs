using MediatR;
using VacanciesProject.Application.ViewModel;
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Command;

public record UpdateTaskStatusCommand
(
	int TaskId,
	WorkTaskStatus Status
)
: IRequest<ResponseViewModel<bool>>;