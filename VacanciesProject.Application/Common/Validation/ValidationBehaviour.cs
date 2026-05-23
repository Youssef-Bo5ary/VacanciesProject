using FluentValidation;
using MediatR;

namespace VacanciesProject.Application.Common.Validation;

public class ValidationBehavior<TRequest, TResponse>
	(IEnumerable<IValidator<TRequest>> validators)
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : notnull

{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		var context = new ValidationContext<TRequest>(request);
		var validationResults =
			await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

		// if there is any error put it in failure object
		var failure =
			validationResults
			.Where(r => r.Errors.Any())
			.SelectMany(r => r.Errors)
			.ToList();

		if (failure.Any())
			throw new ValidationException(failure);
		return await next();

	}
}
