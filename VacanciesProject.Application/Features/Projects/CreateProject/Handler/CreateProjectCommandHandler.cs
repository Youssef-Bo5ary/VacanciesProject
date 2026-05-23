using MediatR;
using VacanciesProject.Application.Features.Projects.CreateProject.Command;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.ViewModel;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Features.Projects.CreateProject.Handler;

public class CreateProjectCommandHandler
	: IRequestHandler<CreateProjectCommand, ResponseViewModel<int>>
{
	private readonly IApplicationDbContext _context;
	private readonly ICurrentUserService _currentUserService;

	public CreateProjectCommandHandler(
		IApplicationDbContext context,
		ICurrentUserService currentUserService)
	{
		_context = context;
		_currentUserService = currentUserService;
	}

	public async Task<ResponseViewModel<int>> Handle(
		CreateProjectCommand request,
		CancellationToken cancellationToken)
	{
		var project = new Project
		{
			Name = request.Name,
			Description = request.Description,
			CreatedAt = DateTime.UtcNow,
			UserId = _currentUserService.UserId!.Value
		};

		await _context.Projects.AddAsync(project, cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);

		return new ResponseViewModel<int>
		{
			Data = project.Id,
			IsSucsess = true,
			Message = "Project created successfully"
		};
	}
}