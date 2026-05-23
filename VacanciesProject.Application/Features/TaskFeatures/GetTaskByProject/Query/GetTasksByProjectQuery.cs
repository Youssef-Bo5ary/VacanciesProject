
using MediatR;
using VacanciesProject.Application.Common.Pagination;
using VacanciesProject.Application.Dtos;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Query;

public record GetTasksByProjectQuery
(
	int ProjectId
)
: PaginationRequest,
  IRequest<ResponseViewModel<PaginatedList<TaskListDto>>>;
