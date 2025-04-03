using System.ComponentModel.DataAnnotations;
namespace Domain.Enums;


public enum ApiResultStatusCode
{

    [Display(Name = "Ok")]
    Ok = 200,

    [Display(Name = "Success")]
    Success = 201,

    [Display(Name = "Created")]
    Created = 202,

    [Display(Name = "InternalServerError")]
    InternalServerError = 203,

    [Display(Name = "UnprocessableEntity")]
    UnprocessableEntity = 204,

    [Display(Name = "Accepted")]
    Accepted = 205,

    [Display(Name = "Server Error")]
    ServerError = 500,

    [Display(Name = "Bad Request Error")]
    BadRequest = 400,

    [Display(Name = "Not Found")]
    NotFound = 404,


    [Display(Name = "Request Process Error")]
    EntityProcessError = 422,

    [Display(Name = "Authentication Error")]
    UnAuthorized = 401,

    [Display(Name = "Authorization Error")]
    Forbidden = 403,

    [Display(Name = "Not Acceptable")]
    NotAcceptable = 406,

    [Display(Name = "Failed Dependency")]
    FailedDependency = 424
}
