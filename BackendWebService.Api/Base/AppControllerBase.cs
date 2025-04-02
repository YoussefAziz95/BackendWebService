using Application.Contracts.DTOs;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.Validators.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Base
{
    /// <summary>
    /// Base controller for the application.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        /// <summary>
        /// Generates an appropriate HTTP response based on the provided response status code.
        /// </summary>
        /// <typeparam name="T">The type of data in the response.</typeparam>
        /// <param name="response">The response containing data and status code.</param>
        /// <returns>An object result representing the HTTP response.</returns>
        public ObjectResult NewResult<T>(IResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
