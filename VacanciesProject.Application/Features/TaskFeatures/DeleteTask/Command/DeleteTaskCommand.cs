using MediatR;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Command;

public record DeleteTaskCommand(int TaskId)
	: IRequest<ResponseViewModel<bool>>;