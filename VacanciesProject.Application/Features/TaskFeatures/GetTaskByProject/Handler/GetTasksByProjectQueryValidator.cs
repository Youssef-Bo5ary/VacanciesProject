using FluentValidation;
using global::VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Query;

namespace VacanciesProject.Application.Features.TaskFeatures.GetTaskByProject.Handler;

public class GetTasksByProjectQueryValidator
	: AbstractValidator<GetTasksByProjectQuery>
{
	public GetTasksByProjectQueryValidator()
	{
		RuleFor(x => x.ProjectId)
			.GreaterThan(0);

		RuleFor(x => x.PageIndex)
			.GreaterThan(0);

		RuleFor(x => x.PageSize)
			.GreaterThan(0)
			.LessThanOrEqualTo(100);
	}
}
