using FluentValidation;
using VacanciesProject.Application.Features.Projects.GetAllProjects.Query;

namespace VacanciesProject.Application.Features.Projects.GetAllProjects.Handler;

public class GetAllProjectsQueryValidator
	: AbstractValidator<GetAllProjectsQuery>
{
	public GetAllProjectsQueryValidator()
	{
		RuleFor(x => x.PageIndex)
			.GreaterThan(0);

		RuleFor(x => x.PageSize)
			.GreaterThan(0)
			.LessThanOrEqualTo(100);
	}
}