using System.Threading.Tasks;

namespace Application.Validators.Common
{
    /// <summary>
    /// Interface for base validation model.
    /// </summary>
    public interface IBaseValidationModel
    {
        /// <summary>
        /// Validates the model object asynchronously using the provided validator.
        /// </summary>
        /// <param name="validator">The validator instance.</param>
        /// <param name="modelObj">The model object to validate.</param>
        /// <returns>A task representing the asynchronous operation with a boolean indicating whether the validation succeeded.</returns>
        Task<bool> Validate(object validator, IBaseValidationModel modelObj);
    }
}
