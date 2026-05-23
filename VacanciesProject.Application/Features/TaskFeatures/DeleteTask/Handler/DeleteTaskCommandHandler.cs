using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;

namespace VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Handler;

public class DeleteTaskCommandHandler
	: IRequestHandler<DeleteTaskCommand, ResponseViewModel<bool>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public DeleteTaskCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<bool>> Handle(
		DeleteTaskCommand request,
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

		_context.Taskss.Remove(task);

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<bool>
		{
			IsSucsess = true,
			Message = "Task deleted successfully",
			Data = true
		};
	}
}