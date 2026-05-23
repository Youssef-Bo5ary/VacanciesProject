using FluentValidation;
using VacanciesProject.Application.Features.Projects.CreateProject.Command;

namespace VacanciesProject.Application.Features.Projects.CreateProject.Handler;

public class CreateProjectCommandValidator
	: AbstractValidator<CreateProjectCommand>
{
	public CreateProjectCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Project name is required")
			.MaximumLength(100);

		RuleFor(x => x.Description)
			.NotEmpty()
			.WithMessage("Description is required")
			.MaximumLength(500);
	}
}