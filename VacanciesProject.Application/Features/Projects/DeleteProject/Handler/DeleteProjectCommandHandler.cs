using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Features.Projects.DeleteProject.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.Projects.DeleteProject.Handler;

public class DeleteProjectCommandHandler
	: IRequestHandler<DeleteProjectCommand, ResponseViewModel<bool>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public DeleteProjectCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<bool>> Handle(
		DeleteProjectCommand request,
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

		_context.Projects.Remove(project);

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<bool>
		{
			IsSucsess = true,
			Message = "Project deleted successfully",
			Data = true
		};
	}
}