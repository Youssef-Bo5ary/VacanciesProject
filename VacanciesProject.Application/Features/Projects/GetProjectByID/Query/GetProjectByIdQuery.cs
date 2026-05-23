using MediatR;
using VacanciesProject.Application.Dtos;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.GetProjectByID.Query;

public record GetProjectByIdQuery(int Id)
	: IRequest<ResponseViewModel<ProjectDetailsDto>>;