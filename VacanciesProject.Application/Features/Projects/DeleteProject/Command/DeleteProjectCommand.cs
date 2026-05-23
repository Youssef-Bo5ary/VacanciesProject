using MediatR;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.DeleteProject.Command;

public record DeleteProjectCommand(int Id)
	: IRequest<ResponseViewModel<bool>>;