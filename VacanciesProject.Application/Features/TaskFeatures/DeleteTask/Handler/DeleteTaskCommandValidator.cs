using FluentValidation;
using VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Command;

namespace VacanciesProject.Application.Features.TaskFeatures.DeleteTask.Handler;

public class DeleteTaskCommandValidator
	: AbstractValidator<DeleteTaskCommand>
{
	public DeleteTaskCommandValidator()
	{
		RuleFor(x => x.TaskId)
			.GreaterThan(0);
	}
}