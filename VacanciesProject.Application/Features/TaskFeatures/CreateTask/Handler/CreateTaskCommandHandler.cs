using MediatR;
using Microsoft.EntityFrameworkCore;
using VacanciesProject.Application.Features.TaskFeatures.CreateTask.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;
using VacanciesProject.Domain.Entity;
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Application.Features.TaskFeatures.CreateTask.Handler;

public class CreateTaskCommandHandler
	: IRequestHandler<CreateTaskCommand, ResponseViewModel<int>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public CreateTaskCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<int>> Handle(
		CreateTaskCommand request,
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
			return new ResponseViewModel<int>
			{
				IsSucsess = false,
				Message = "Project not found",
				Data = 0
			};
		}

		var task = new Taskss
		{
			Title = request.Title,
			Description = request.Description,
			DueDate = request.DueDate,
			Priority = request.Priority,
			Status = WorkTaskStatus.Pending,
			ProjectId = request.ProjectId
		};

		await _context.Taskss.AddAsync(task, cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<int>
		{
			IsSucsess = true,
			Message = "Task created successfully",
			Data = task.Id
		};
	}
}