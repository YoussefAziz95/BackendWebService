namespace Application.Contracts.Features;

public interface IMediator
{
    IResponse<TResponse> Handle<TResponse>(IRequest<TResponse> request);
    Task<IResponse<TResponse>> HandleAsync<TResponse>(IRequest<TResponse> request);
    IResponse<TResponse> HandleById<TResponse>(int id);
}

