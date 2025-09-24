using Application.Contracts.Features;
using FluentValidation;
using FluentValidation.Results;

namespace Application.ServicesImplementation.Common;

public class ValidateCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, IResponse<TResponse>>
    where TRequest : IRequest<IResponse<TResponse>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidateCommandBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<IResponse<TResponse>> Handle(TRequest request, RequestHandlerDelegate<IResponse<TResponse>> next, CancellationToken cancellationToken = default)
    {
        var errors = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validationResult = await validator.ValidateAsync(new ValidationContext<TRequest>(request), cancellationToken);

            if (!validationResult.IsValid)
                errors.AddRange(validationResult.Errors);
        }

        if (errors.Any())
            throw new ValidationException(errors);

        return await next();
    }
}
