using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Handler;

public class UpdateTaskStatusCommandHandler
	: IRequestHandler<UpdateTaskStatusCommand, ResponseViewModel<bool>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public UpdateTaskStatusCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<bool>> Handle(
		UpdateTaskStatusCommand request,
		CancellationToken cancellationToken)
	{
		var task = await _context.Taskss
			.Include(x => x.Project)
			.FirstOrDefaultAsync(
				x =>
					x.Id == request.TaskId &&
					x.Project.UserId == _currentUserService.UserId,
				cancellationToken);

		if (task is null)
		{
			return new ResponseViewModel<bool>
			{
				IsSucsess = false,
				Message = "Task not found",
				Data = false
			};
		}

		task.Status = request.Status;

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<bool>
		{
			IsSucsess = true,
			Message = "Task status updated successfully",
			Data = true
		};
	}
}