using Application.Exceptions;
using FluentValidation;

namespace Application.Validators.Common
{
    /// <summary>
    /// Asynchronous base validation model for validating objects using FluentValidation.
    /// </summary>
    /// <typeparam name="T">The type of object to validate.</typeparam>
    public class AsyncBaseValidationModel<T> : IBaseValidationModel
    {
        /// <summary>
        /// Validates the specified model object asynchronously using the provided validator.
        /// </summary>
        /// <param name="validator">The validator instance.</param>
        /// <param name="modelObj">The model object to validate.</param>
        /// <returns>A task representing the asynchronous operation with a boolean indicating whether the validation succeeded.</returns>
        public async Task<bool> Validate(object validator, IBaseValidationModel modelObj)
        {
            var instance = (IValidator<T>)validator;
            var result = await instance.ValidateAsync((T)modelObj);

            if (!result.IsValid && result.Errors.Any())
            {
                throw new CustomValidationException(result.Errors);
            }
            return result.IsValid;
        }
    }
}
