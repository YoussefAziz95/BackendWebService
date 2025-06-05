using Application.Contracts.Features;
using Domain.Enums;
using SharedKernel.Extensions;
using System.Diagnostics;

namespace Application.Features.Common;

public class Response
{
    public bool Succeeded { get; set; }
    public ApiResultStatusCode StatusCode { get; set; }

    public string Message { get; set; }
    public string RequestId { get; }

    public Response(bool succeeded, ApiResultStatusCode statusCode, string message = null)
    {
        Succeeded = succeeded;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToDisplay();
        RequestId = Activity.Current?.TraceId.ToHexString() ?? string.Empty;
    }

    public Response()
    {
    }

}

public class Response<TData> : IResponse<TData>
{
    public TData Data { get; set; }
    public ApiResultStatusCode StatusCode { get; set; }

    public bool Succeeded { get; set; }

    public string Message { get; set; }

    public List<string>? Errors { get; set; }
    public string? Error { get; set; }

    public Response(bool succeeded, ApiResultStatusCode statusCode, TData data, string message = null)
    {
        Data = data;
    }

    public Response()
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided data and optional message.
    /// </summary>
    /// <param name="data">The data returned by the operation.</param>
    /// <param name="message">An optional message describing the outcome of the operation.</param>
    public Response(TData data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided message and sets the <see cref="Succeeded"/> property to <c>false</c>.
    /// </summary>
    /// <param name="message">The message describing the failure of the operation.</param>
    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with the provided message and success status.
    /// </summary>
    /// <param name="message">The message describing the outcome of the operation.</param>
    /// <param name="succeeded">The success status of the operation.</param>
    public Response(string message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }
}