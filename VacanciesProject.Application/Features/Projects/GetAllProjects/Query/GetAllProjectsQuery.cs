using MediatR;
using VacanciesProject.Application.Common.Pagination;
using VacanciesProject.Application.Dtos;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.GetAllProjects.Query;

public record GetAllProjectsQuery
	: PaginationRequest,
	  IRequest<ResponseViewModel<PaginatedList<ProjectListDto>>>;