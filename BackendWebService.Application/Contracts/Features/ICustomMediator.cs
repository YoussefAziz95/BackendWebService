namespace Application.Contracts.Features;

public interface ICustomMediator
{
    IResponse<TResponse> Send<TResponse>(IRequest<TResponse> request);
    Task<IResponse<TResponse>> SendAsync<TResponse>(IRequest<TResponse> request);
    IResponse<TResponse> SendById<TResponse>(int id);
}

