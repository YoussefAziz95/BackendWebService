namespace Application.Contracts.Features;

public interface IRequest<TResponse> { }

public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    IResponse<TResponse> Handle(TRequest request);
}
public interface IRequestHandlerAsync<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<IResponse<TResponse>> HandleAsync(TRequest request);
}
