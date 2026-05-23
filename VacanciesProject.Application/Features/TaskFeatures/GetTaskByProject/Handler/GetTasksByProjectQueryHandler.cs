using global::VacanciesProject.Application.Common.Pagination;
using global::VacanciesProject.Application.Dtos;
using global::VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Query;
using global::VacanciesProject.Application.Interfaces;
using global::VacanciesProject.Application.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Handler;


public class GetTasksByProjectQueryHandler
	: IRequestHandler<
		GetTasksByProjectQuery,
		ResponseViewModel<PaginatedList<TaskListDto>>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public GetTasksByProjectQueryHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<PaginatedList<TaskListDto>>> Handle(
		GetTasksByProjectQuery request,
		CancellationToken cancellationToken)
	{
		var projectExists = await _context.Projects
			.AnyAsync(
				x =>
					x.Id == request.ProjectId &&
					x.UserId == _currentUserService.UserId,
				cancellationToken);

		if (!projectExists)
		{
			return new ResponseViewModel<PaginatedList<TaskListDto>>
			{
				IsSucsess = false,
				Message = "Project not found",
				Data = null
			};
		}

		var query = _context.Taskss
			.AsNoTracking()
			.Where(x => x.ProjectId == request.ProjectId)
			.OrderByDescending(x => x.Id)
			.Select(x => new TaskListDto
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				Status = x.Status,
				DueDate = x.DueDate,
				Priority = x.Priority
			});

		var tasks =  PaginatedList<TaskListDto>
			.Create(
				query,
				request.PageIndex,
				request.PageSize);

		return new ResponseViewModel<PaginatedList<TaskListDto>>
		{
			IsSucsess = true,
			Message = "Tasks retrieved successfully",
			Data = tasks
		};
	}
}
