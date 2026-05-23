using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Common.Pagination;
using VacanciesProject.Application.Dtos;
using VacanciesProject.Application.Features.Projects.GetAllProjects.Query;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.GetAllProjects.Handler;

public class GetAllProjectsQueryHandler
	: IRequestHandler<
		GetAllProjectsQuery,
		ResponseViewModel<PaginatedList<ProjectListDto>>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public GetAllProjectsQueryHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<PaginatedList<ProjectListDto>>> Handle(
		GetAllProjectsQuery request,
		CancellationToken cancellationToken)
	{
		var query = _context.Projects
			.AsNoTracking()
			.Where(x => x.UserId == _currentUserService.UserId)
			.OrderByDescending(x => x.CreatedAt)
			.Select(x => new ProjectListDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				CreatedAt = x.CreatedAt
			});

		var projects =  PaginatedList<ProjectListDto>
			.Create(
				query,
				request.PageIndex,
				request.PageSize);

		return new ResponseViewModel<PaginatedList<ProjectListDto>>
		{
			IsSucsess = true,
			Message = "Projects retrieved successfully",
			Data = projects
		};
	}
}