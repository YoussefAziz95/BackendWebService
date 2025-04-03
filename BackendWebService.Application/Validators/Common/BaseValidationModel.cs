using Application.Exceptions;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Validators.Common
{
    /// <summary>
    /// Base class for validation models.
    /// </summary>
    /// <typeparam name="T">The type of the model being validated.</typeparam>
    public class BaseValidationModel<T> : IBaseValidationModel
    {
        /// <summary>
        /// Validates the model object using the provided validator.
        /// </summary>
        /// <param name="validator">The validator instance.</param>
        /// <param name="modelObj">The model object to be validated.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, returning true if the validation succeeds, otherwise false.</returns>
        public Task<bool> Validate(object validator, IBaseValidationModel modelObj)
        {
            var instance = (IValidator<T>)validator;
            var result = instance.Validate((T)modelObj);

            if (!result.IsValid && result.Errors.Any())
            {
                throw new CustomValidationException(result.Errors);
            }
            return Task.FromResult(result.IsValid);
        }
    }
}
