using FluentValidation;
using VacanciesProject.Application.Features.Projects.GetProjectByID.Query;

namespace VacanciesProject.Application.Features.Projects.GetProjectByID.Handler;

public class GetProjectByIdQueryValidator
	: AbstractValidator<GetProjectByIdQuery>
{
	public GetProjectByIdQueryValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0);
	}
}