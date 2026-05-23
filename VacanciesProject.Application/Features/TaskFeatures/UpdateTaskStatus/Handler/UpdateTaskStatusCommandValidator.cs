using FluentValidation;
using VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Command;

namespace VacanciesProject.Application.Features.TaskFeatures.UpdateTaskStatus.Handler;

public class UpdateTaskStatusCommandValidator
	: AbstractValidator<UpdateTaskStatusCommand>
{
	public UpdateTaskStatusCommandValidator()
	{
		RuleFor(x => x.TaskId)
			.GreaterThan(0);

		RuleFor(x => x.Status)
			.IsInEnum();
	}
}