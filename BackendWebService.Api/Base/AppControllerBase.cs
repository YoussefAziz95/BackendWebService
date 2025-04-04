using Application.Contracts.DTOs;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
namespace BackendWebService.Api.Base;

[Route("api/[controller]")]
[ApiController]
public class AppControllerBase : ControllerBase
{
    public ObjectResult NewResult<T>(IResponse<T> response)
    {
        switch (response.StatusCode)
        {
            case ApiResultStatusCode.Ok:
                return new OkObjectResult(response);
            case ApiResultStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case ApiResultStatusCode.UnAuthorized:
                return new UnauthorizedObjectResult(response);
            case ApiResultStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case ApiResultStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case ApiResultStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case ApiResultStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }
    }
}
