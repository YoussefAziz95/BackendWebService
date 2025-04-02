using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Validators.Common
{
    /// <summary>
    /// Attribute for validating models before action execution.
    /// </summary>
    public sealed class ModelValidatorAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Executes before the action method is invoked.
        /// </summary>
        /// <param name="context">The context for the action execution.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var actionArgument in context.ActionArguments)
            {
                // Validate that the model has a validator and resolve it
                if (actionArgument.Value is IBaseValidationModel model)
                {
                    var modelType = actionArgument.Value.GetType();
                    var genericType = typeof(IValidator<>).MakeGenericType(modelType);
                    var validator = context.HttpContext.RequestServices.GetService(genericType);

                    if (validator != null!)
                    {
                        try
                        {
                            // Execute validator to validate model
                            model.Validate(validator, model);
                        }
                        catch (CustomValidationException ex)
                        {
                            context.Result = new BadRequestObjectResult(ex.Errors);
                            return;
                        }
                    }
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
