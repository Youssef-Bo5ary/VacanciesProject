using FluentValidation;
using VacanciesProject.Application.Features.TaskFeatures.CreateTask.Command;

namespace VacanciesProject.Application.Features.TaskFeatures.CreateTask.Handler;

public class CreateTaskCommandValidator
	: AbstractValidator<CreateTaskCommand>
{
	public CreateTaskCommandValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(100);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(500);

		RuleFor(x => x.ProjectId)
			.GreaterThan(0);

		RuleFor(x => x.Priority)
			.IsInEnum();

		RuleFor(x => x.DueDate)
			.GreaterThan(DateTime.UtcNow.Date)
			.When(x => x.DueDate.HasValue);
	}
}