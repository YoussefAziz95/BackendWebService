using FluentValidation.Results;

namespace Application.Exceptions
{
    /// <summary>
    /// Exception thrown when custom validation fails.
    /// </summary>
    public sealed class CustomValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidationException"/> class.
        /// </summary>
        public CustomValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidationException"/> class with validation failures.
        /// </summary>
        /// <param name="failures">The collection of validation failures.</param>
        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.Select(e => e.ErrorMessage).ToList();
            ValidationFailures = failures.ToList();
        }

        /// <summary>
        /// Gets the list of validation failures.
        /// </summary>
        public List<ValidationFailure> ValidationFailures { get; }

        /// <summary>
        /// Gets the list of error messages.
        /// </summary>
        public List<string> Errors { get; }
    }
}
