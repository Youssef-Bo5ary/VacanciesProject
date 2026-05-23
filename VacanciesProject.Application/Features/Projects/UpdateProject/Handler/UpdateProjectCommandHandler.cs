using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Features.Projects.UpdateProject.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.UpdateProject.Handler;

public class UpdateProjectCommandHandler
	: IRequestHandler<UpdateProjectCommand, ResponseViewModel<bool>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public UpdateProjectCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<bool>> Handle(
		UpdateProjectCommand request,
		CancellationToken cancellationToken)
	{
		var project = await _context.Projects
			.FirstOrDefaultAsync(
				x => x.Id == request.Id
				  && x.UserId == _currentUserService.UserId,
				cancellationToken);

		if (project is null)
		{
			return new ResponseViewModel<bool>
			{
				IsSucsess = false,
				Message = "Project not found",
				Data = false
			};
		}

		project.Name = request.Name;
		project.Description = request.Description;

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<bool>
		{
			IsSucsess = true,
			Message = "Project updated successfully",
			Data = true
		};
	}
}