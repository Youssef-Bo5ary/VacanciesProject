using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacanciesProject.Application.Features.Projects.CreateProject.Command;
using VacanciesProject.Application.Features.Projects.DeleteProject.Command;
using VacanciesProject.Application.Features.Projects.GetAllProjects.Query;
using VacanciesProject.Application.Features.Projects.GetProjectByID.Query;
using VacanciesProject.Application.Features.Projects.UpdateProject.Command;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProjectsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateProjectCommand command)
	{
		var result = await _mediator.Send(command);

		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await _mediator.Send(
			new DeleteProjectCommand(id));

		return Ok(result);
	}

	[HttpPut]
	public async Task<IActionResult> Update(
	UpdateProjectCommand command)
	{
		var result = await _mediator.Send(command);

		return Ok(result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(
	[FromQuery] GetAllProjectsQuery query)
	{
		var result = await _mediator.Send(query);

		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var result = await _mediator.Send(
			new GetProjectByIdQuery(id));

		return Ok(result);
	}
}