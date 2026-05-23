using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Dtos;
using VacanciesProject.Application.Features.Projects.GetProjectByID.Query;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.GetProjectByID.Handler;

public class GetProjectByIdQueryHandler
	: IRequestHandler<
		GetProjectByIdQuery,
		ResponseViewModel<ProjectDetailsDto>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public GetProjectByIdQueryHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<ProjectDetailsDto>> Handle(
		GetProjectByIdQuery request,
		CancellationToken cancellationToken)
	{
		var project = await _context.Projects
			.AsNoTracking()
			.Where(x =>
				x.Id == request.Id &&
				x.UserId == _currentUserService.UserId)
			.Select(x => new ProjectDetailsDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				CreatedAt = x.CreatedAt
			})
			.FirstOrDefaultAsync(cancellationToken);

		if (project is null)
		{
			return new ResponseViewModel<ProjectDetailsDto>
			{
				IsSucsess = false,
				Message = "Project not found",
				Data = null
			};
		}

		return new ResponseViewModel<ProjectDetailsDto>
		{
			IsSucsess = true,
			Message = "Project retrieved successfully",
			Data = project
		};
	}
}