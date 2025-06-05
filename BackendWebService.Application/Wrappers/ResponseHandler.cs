using Application.Contracts.Features;
using Application.Features.Common;
using Domain.Enums;

namespace Application.Wrappers;

public class ResponseHandler
{
    public IResponse<T> Deleted<T>()
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true,
            Message = "Deleted Successfully"
        };
    }
    public IResponse<T> EmailVerified<T>()
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true,
            Message = "EmailDto Verified Successfully"
        };
    }
    public IResponse<T> EmailSent<T>()
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true,
            Message = "EmailDto Sent Successfully"
        };
    }
    public IResponse<T> PasswordUpdated<T>()
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true,
            Message = "Password Updated Successfully"
        };
    }

    public IResponse<T> Success<T>(T entity)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true
        };
    }
    public IResponse<T> Success<T>(string message = null!)
    {
        return new Response<T>()
        {
            Message = message,
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true
        };
    }

    public IResponse<int> Success(int id)
    {
        return new Response<int>()
        {
            Data = id,
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true
        };
    }
    public IResponse<T> Uploaded<T>(T entity)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true,
            Message = "Uploaded Successfully"
        };
    }
    public IResponse<T> Updated<T>(T entity, string message = null!)
    {
        return new Response<T>()
        {
            Data = entity,
            Message = message == null! ? "Updated Successfully" : message,
            StatusCode = ApiResultStatusCode.Ok,
            Succeeded = true
        };
    }
    public IResponse<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.UnAuthorized,
            Succeeded = true,
            Message = "UnAuthorized",
        };
    }
    public IResponse<T> BadRequest<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.BadRequest,
            Succeeded = false,
            Message = message == null! ? "Bad Request" : message
        };
    }
    public IResponse<T> BadRequest<T>(List<string> errors)
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.BadRequest,
            Succeeded = false,
            Errors = errors
        };
    }
    public IResponse<T> NotFound<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.NotFound,
            Succeeded = false,
            Message = message == null! ? "Not Found" : message
        };
    }
    public IResponse<T> Created<T>(T entity, object meta = null!)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = ApiResultStatusCode.Created,
            Succeeded = true
        };
    }
    public IResponse<int> Created(int id)
    {
        return new Response<int>()
        {
            Data = id,
            StatusCode = ApiResultStatusCode.Created,
            Succeeded = true
        };
    }
    public IResponse<T> CannotDelete<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = ApiResultStatusCode.FailedDependency,
            Succeeded = false,
            Message = message == null! ? "Connot Delete Failed Dependency" : message
        };
    }
}

