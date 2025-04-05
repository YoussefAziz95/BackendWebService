using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ServicesImplementation.Common;

public class ValidateCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidateCommandBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest message,RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) // Change MessageHandlerDelegate to RequestHandlerDelegate
    {
        var errors = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validationResult =
                await validator.ValidateAsync(new ValidationContext<TRequest>(message), cancellationToken);

            if (!validationResult.IsValid)
                errors.AddRange(validationResult.Errors);
        }

        if (errors.Any())
            throw new ValidationException(errors);

        return await next();
    }

}
