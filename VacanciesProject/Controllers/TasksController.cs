using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacanciesProject.Application.Features.TaskFeatures.CreateTask.Command;
using VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Command;
using VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Query;
using VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Command;

namespace VacanciesProject.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TasksController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateTaskCommand command)
		{
			var result = await _mediator.Send(command);

			return Ok(result);
		}

		[HttpPut("status")]
		public async Task<IActionResult> UpdateStatus(UpdateTaskStatusCommand command)
		{
			var result = await _mediator.Send(command);

			return Ok(result);
		}

		[HttpDelete("{taskId}")]
		public async Task<IActionResult> Delete(int taskId)
		{
			var result = await _mediator.Send(
				new DeleteTaskCommand(taskId));

			return Ok(result);
		}

		[HttpGet("project/{projectId}")]
		public async Task<IActionResult> GetByProject(
	int projectId,
	[FromQuery] int pageNumber = 1,
	[FromQuery] int pageSize = 10)
		{
			var query = new GetTasksByProjectQuery(projectId)
			{
				PageIndex = pageNumber,
				PageSize = pageSize
			};

			var result = await _mediator.Send(query);

			return Ok(result);
		}
	}
}
