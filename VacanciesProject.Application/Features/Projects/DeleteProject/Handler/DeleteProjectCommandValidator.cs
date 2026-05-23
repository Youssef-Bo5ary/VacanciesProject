using FluentValidation;
using VacanciesProject.Application.Features.Projects.DeleteProject.Command;

namespace VacanciesProject.Application.Features.Projects.DeleteProject.Handler;

public class DeleteProjectCommandValidator
	: AbstractValidator<DeleteProjectCommand>
{
	public DeleteProjectCommandValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0);
	}
}