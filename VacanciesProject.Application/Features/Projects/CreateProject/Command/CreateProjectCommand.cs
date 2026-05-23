using MediatR;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.CreateProject.Command;

public record CreateProjectCommand
	(
		string Name,
		string Description
	)
	: IRequest<ResponseViewModel<int>>;