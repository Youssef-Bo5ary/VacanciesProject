using MediatR;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.UpdateProject.Command;

public record UpdateProjectCommand
(
	int Id,
	string Name,
	string Description
)
: IRequest<ResponseViewModel<bool>>;