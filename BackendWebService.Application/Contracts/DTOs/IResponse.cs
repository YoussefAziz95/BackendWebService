using Domain.Enums;

namespace Application.Contracts.DTOs;

public interface IResponse<T>
{
    ApiResultStatusCode StatusCode { get; set; }

    bool Succeeded { get; set; }

    string Message { get; set; }

    List<string>? Errors { get; set; }

    T? Data { get; set; }
}
