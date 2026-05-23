using FluentValidation;
using VacanciesProject.Application.Features.Projects.UpdateProject.Command;

namespace VacanciesProject.Application.Features.Projects.UpdateProject.Handler;

public class UpdateProjectCommandValidator
	: AbstractValidator<UpdateProjectCommand>
{
	public UpdateProjectCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0);

		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(100);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(500);
	}
}